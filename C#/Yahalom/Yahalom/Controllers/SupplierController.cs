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
    public class SupplierController : Controller
    {
        private ISupplierBL _supplierBL;
        // קונסטרקטור שבזמן שמייצרים 
        //CustomerController
        // אז הוא יהיה חייב לקבל טיפוס מסוג הממשק של 
        //ICustomerBL
        //והוא יזריק תלות אליו
        public SupplierController(ISupplierBL supplierBL)
        {
            _supplierBL = supplierBL;
        }


        // פונקציה מספר 2 - הרשמה
        // פונקציה להוספת ספק חדש
        //[HttpPost]
        //public BaseResult<int> CreateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
        //    int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId)
        //{
        //    return _supplierBL.CreateSupplier(FirstName,LastName, Password, Phone, Email, BusinessName,
        //    IdCategory, IdSecondSupplierCategory, PriceFrom, PriceUntill,  AboutMe, PlaceId);
        //}
        [HttpPost]
        public BaseResult<int> CreateSupplier(SupplierBasicDTO supplier)
        {
            return _supplierBL.CreateSupplier(supplier);
        }
        // פונקציה מספר 8 - עדכון ושינוי פרטים אישיים לספק
        [HttpPut]
        public BaseResult<int> UpdateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
            int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId)
        {
            return _supplierBL.UpdateSupplier(FirstName, LastName, Password, Phone, Email, BusinessName,
            IdCategory, IdSecondSupplierCategory, PriceFrom, PriceUntill, AboutMe, PlaceId);
        }

        // פונקציה מספר 12 הצגת ספקים לפי סינון לקוח
        [HttpGet]
        //[Route("getCustomer/{email}/{password}")]
        public BaseResult<List<SupplierDTO>> sortSupplier(int Id_Categoty, int Place_Id, int Price_from, int Price_Until)
        {
            return _supplierBL.SortSupplier(Id_Categoty, Place_Id, Price_from, Price_Until);
        }

        // פונקציה מספר 25
        // פונקציית סינון קטגוריות ראשיות – בלחיצה על כפתור קטגוריות יוצגו הקטגוריות הראשיות
        [HttpGet]
        public BaseResult<List<SupplierCategoryDTO>> getSupplierCategory()
        {
            return _supplierBL.getSupplierCategory();
        }

        // פונקציה מספר 26
        //פונקציית סינון תתי קטגוריות – בלחיצה על קטגוריה יוצגו ללקוח תתי קטגוריות
        [HttpGet]
        public BaseResult<List<SecondCtegoryDTO>> getSecondCtegory(int Id_Categoty)
        {
            return _supplierBL.getSecondCtegory(Id_Categoty);
        }

        // פונקציה מספר 27 הצגת אזורי מתן שירות
        [HttpGet]
        public BaseResult<List<PlaceIdDTO>> GetPlaces()
        {
            return _supplierBL.GetPlaces();
        }
    }
}
