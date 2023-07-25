using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICustomerBL
    {
        // פונקציה מספר 1 הרשמת לקוח
        BaseResult<int> CreateCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom);
        //פונקציה מספר 13 עדכון פרופיל לקוח
        BaseResult<int> EditCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom);
        BaseResult<DateTime?> getDateOfWedding(int idCustomer);
    }
}
