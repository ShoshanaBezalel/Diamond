using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ISupplierBL
    {
        // פונקציה מספר 2 הרשמת ספק
        //BaseResult<int> CreateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
        //    int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId);

        BaseResult<int> CreateSupplier(SupplierBasicDTO supplier);
        // פונקציה מספר 8 עדכון ושינוי פרטי ספק
        BaseResult<int> UpdateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
            int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId);
        // פונקציה מספר 12 הצגת ספקים לפי סינון לקוח
        BaseResult<List<SupplierDTO>> SortSupplier(int Id_Categoty, int Place_Id, int Price_from, int Price_Until);
        // פונקציה מספר 25
        // פונקציית סינון קטגוריות ראשיות – בלחיצה על כפתור קטגוריות יוצגו הקטגוריות הראשיות
        BaseResult<List<SupplierCategoryDTO>> getSupplierCategory();
        // פונקציה מספר 26
        //פונקציית סינון תתי קטגוריות – בלחיצה על קטגוריה יוצגו ללקוח תתי קטגוריות
        BaseResult<List<SecondCtegoryDTO>> getSecondCtegory(int Id_Categoty);
        // פונקציה מספר 27 הצגת אזורי מתן שירות
        BaseResult<List<PlaceIdDTO>> GetPlaces();

    }
}

