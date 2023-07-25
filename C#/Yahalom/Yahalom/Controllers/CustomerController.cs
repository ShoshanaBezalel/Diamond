
using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yahalom.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private ICustomerBL _CustomerBL;
        // קונסטרקטור שבזמן שמייצרים 
        //CustomerController
        // אז הוא יהיה חייב לקבל טיפוס מסוג הממשק של 
        //ICustomerBL
        //והוא יזריק תלות אליו
        public CustomerController(ICustomerBL CustomerBL)
        {
            _CustomerBL = CustomerBL;
        }

        // פונקציה מספר 1 - הרשמה
        // פונקציה להוספת לקוח חדש
        [HttpPost]
        public BaseResult<int> CreateCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom)
        {
            
            return _CustomerBL.CreateCustomer( FirstName,  LastName,  Password,   Phone,  Email,   DateOfWedding,  IsGroom);
        }
        [HttpPost]
        // פונקציה מספר 13 עדכון פרופיל לקוח
        public BaseResult<int> EditCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom)
        {

            return _CustomerBL.EditCustomer(FirstName, LastName, Password, Phone, Email, DateOfWedding, IsGroom);
        }

        [HttpGet]
        public BaseResult<DateTime?> getDateOfWedding(int idCustomer)
        {

            return _CustomerBL.getDateOfWedding(idCustomer);
        }
    }
}
