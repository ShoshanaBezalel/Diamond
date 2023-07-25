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
    public class InvitationController : Controller
    {
        private IInvitationBL _invitationBL;
        public InvitationController(IInvitationBL invitationBL)
        {
            _invitationBL = invitationBL;
        }

        //  פונקציות מספר 5 6 7 - שליפה של כל ההזמנות של הספק
        // או הזמנות שלא שולמו במלואן
        // או הזמנות שעדיין לא בוצעו בפועל
        [HttpGet]
       [Route("getInvitationSupplier/{IdSuplier}")]
        public BaseResult<List<InvitationDTO>> getInvitationSupplier(int IdSuplier, SupplierInventationStatus? inventationStatus)
        {
            return _invitationBL.getInvitationSupplier(IdSuplier, inventationStatus);
        }

        // פונקציה מספר 9 עדכון שההזמנה שולמה במלואה
        [HttpPut]
        public BaseResult<bool?> UpdateIsPaid(int idInvitation)
        {
            return _invitationBL.UpdateIsPaid(idInvitation);
        }
        // פונקציה מספר 10 הצגת הפרטים של ההזמנה, עבור הספק

        [HttpGet]
        public BaseResult<InvitationDTO> getInvitationDetails(int idInvitation)
        {
            return _invitationBL.getInvitationDetails(idInvitation);
        }
        // פונקציה מספר 11 הצגת הפרטים של הלקוח שביצע את ההזמנה, עבור הספק
        [HttpGet]
        public BaseResult<CustomerDTO> getCustomerDetails(int idInvitation)
        {
            return _invitationBL.getCustomerDetails(idInvitation);
        }


        // פונקציה מספר 22 
       // הצגת ההזמנות ללקוח
        //[HttpGet]
        //public BaseResult<InvitationDTO> getInvitationCustomer(int idCustomer)
        //{
        //    return _invitationBL.getInvitationCustomer(idCustomer);
        //}

        [HttpGet]
        public BaseResult<List<InvitationDTO>> getInvitationCustomer(int idCustomer)
        {
            return _invitationBL.getInvitationCustomer(idCustomer);
        }


        // פונקציה מספר 23 
        // הוספת הזמנה חדשה ללקוח
        [HttpPost]
        public BaseResult<int> CreateInvitationCustomer(DateTime? DateOfInvitation, int? FinalPrice,
            string Location, int? StatusId, DateTime? From, DateTime? To, int? IdCustomer, int? IdSuplier)
        {

            return _invitationBL.CreateInvitationCustomer(DateOfInvitation, FinalPrice,
                 Location, StatusId, From, To, IdCustomer, IdSuplier);
        }
        //פונקציה מספר 24
        //צור קשר- להצגת פרטי הספק ללקוח

        [HttpGet]
        public BaseResult<string> ContactUs(int idInvitation)
        {
            return _invitationBL.ContactUs(idInvitation);
        }
    }
}