using AutoMapper;
using DAL.DB;
using DTO;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SupplierBL : ISupplierBL
    {


        //הזרקת תלויות בקונסטרקטור גם ל
        //DAL
        //וגם להמרה
        //(readonly = משתנה שאי אפשר לשנות את ערכו)

        private readonly YahalomContext _dbContext;
        private readonly IMapper _mapper;

        public SupplierBL(YahalomContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // פונקציה מספר 2 הרשמת ספק
        //public BaseResult<int> CreateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
        //    int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId)
        //{
        //    try
        //    {
        //        Supplier supplierdb = new Supplier(FirstName, LastName, Password, Phone, Email, BusinessName,
        //                 IdCategory, IdSecondSupplierCategory, PriceFrom, PriceUntill, AboutMe, PlaceId);

        //        var createdSupplier = _dbContext.Suppliers.Add(supplierdb);

        //        _dbContext.SaveChanges();

        //        return new BaseResult<int>()
        //        {
        //            Data = createdSupplier.Entity.IdSuplier
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResult<int>()
        //        {
        //            IsError = true,
        //            ErrorCode = ErrorCode.Unexpected,
        //            ErrorMessage = ex.Message
        //        };
        //    }
        //}

        public BaseResult<int> CreateSupplier(SupplierBasicDTO supplier)
        {
            try
            {
                Supplier supplierdb = _mapper.Map<Supplier>(supplier);

                var createdSupplier = _dbContext.Suppliers.Add(supplierdb);

                _dbContext.SaveChanges();

                return new BaseResult<int>()
                {
                    Data = createdSupplier.Entity.IdSuplier
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<int>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }
        // פונקציה מספר 8 שינוי ועדכון פרטי ספק
        public BaseResult<int> UpdateSupplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
            int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId)
        {

            try
            {
                Supplier supplierdb = new Supplier(FirstName, LastName, Password, Phone, Email, BusinessName,
                              IdCategory, IdSecondSupplierCategory, PriceFrom, PriceUntill, AboutMe, PlaceId);
                Supplier UpdateSupplier = _dbContext.Suppliers.SingleOrDefault(x => x.Password.Equals(Password));
                if (UpdateSupplier != null)
                {
                    if (supplierdb.FirstName != null) UpdateSupplier.FirstName = supplierdb.FirstName;
                    if (supplierdb.LastName != null) UpdateSupplier.LastName = supplierdb.LastName;
                    if (supplierdb.Password != null) UpdateSupplier.Password = supplierdb.Password;
                    if (supplierdb.Phone != null) UpdateSupplier.Phone = supplierdb.Phone;
                    if (supplierdb.Email != null) UpdateSupplier.Email = supplierdb.Email;
                    if (supplierdb.BusinessName != null) UpdateSupplier.BusinessName = supplierdb.BusinessName;
                    if (supplierdb.IdCategory != null) UpdateSupplier.IdCategory = supplierdb.IdCategory;
                    if (supplierdb.IdSecondSupplierCategory != null) UpdateSupplier.IdSecondSupplierCategory = supplierdb.IdSecondSupplierCategory;
                    if (supplierdb.PriceFrom != null) UpdateSupplier.PriceFrom = supplierdb.PriceFrom;
                    if (supplierdb.PriceUntill != null) UpdateSupplier.PriceUntill = supplierdb.PriceUntill;
                    if (supplierdb.AboutMe != null) UpdateSupplier.AboutMe = supplierdb.AboutMe;
                    if (supplierdb.IdPlace != null) UpdateSupplier.IdPlace = supplierdb.IdPlace;


                    _dbContext.SaveChanges();

                    return new BaseResult<int>()
                    {
                        Data = UpdateSupplier.IdSuplier
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                return new BaseResult<int>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

        //

        // פונקציה מספר 12 הצגת ספקים לפי סינון לקוח
        // הספקים מסוננים לפי תתי קטגוריות, מיקום, ומחיר
        public BaseResult<List<SupplierDTO>> SortSupplier(int Id_Second_Ctegory, int Place_Id, int Price_from, int Price_Until)
        {
            try
            {
                List<Supplier> sortSupplierdb = _dbContext.Suppliers.Where(x => x.IdSecondSupplierCategory == Id_Second_Ctegory
                && x.IdPlace == Place_Id && x.PriceFrom <= Price_from && x.PriceUntill >= Price_Until).ToList();
                List<SupplierDTO> nameSuppliers = _mapper.Map<List<SupplierDTO>>(sortSupplierdb);
                return new BaseResult<List<SupplierDTO>>()
                {
                    Data = nameSuppliers
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<SupplierDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }
        // פונקציה מספר 25
        // פונקציית סינון קטגוריות ראשיות – בלחיצה על כפתור קטגוריות יוצגו הקטגוריות הראשיות
        public BaseResult<List<SupplierCategoryDTO>> getSupplierCategory()
        {
            try
            {
                List<SupplierCategory> SupplierCategorydb = _dbContext.SupplierCategories.ToList();
                List<SupplierCategoryDTO> SupplierCategory = _mapper.Map<List<SupplierCategoryDTO>>(SupplierCategorydb);
                return new BaseResult<List<SupplierCategoryDTO>>()
                {
                    Data = SupplierCategory
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<SupplierCategoryDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }

        // פונקציה מספר 26
        //פונקציית סינון תתי קטגוריות – בלחיצה על קטגוריה יוצגו ללקוח תתי קטגוריות
        public BaseResult<List<SecondCtegoryDTO>> getSecondCtegory(int Id_Categoty)
        {
            try
            {
                List<SecondCtegory> sortSecondCtegorydb = _dbContext.SecondCtegories.Where(x => x.IdCategoryLinking == Id_Categoty).ToList();
                List<SecondCtegoryDTO> sortSecondCtegory = _mapper.Map<List<SecondCtegoryDTO>>(sortSecondCtegorydb);
                return new BaseResult<List<SecondCtegoryDTO>>()
                {
                    Data = sortSecondCtegory
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<SecondCtegoryDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }
        // פונקציה מספר 27 הצגת אזורי מתן שירות
        public BaseResult<List<PlaceIdDTO>> GetPlaces()
        {

            try
            {
                List<PlaceId> PlaceIdDB = _dbContext.PlaceIds.ToList();
                List<PlaceIdDTO> PlaceId = _mapper.Map<List<PlaceIdDTO>>(PlaceIdDB);
                return new BaseResult<List<PlaceIdDTO>>()
                {
                    Data = PlaceId
                };
            }
            catch (Exception ex)
            {
                return new BaseResult<List<PlaceIdDTO>>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
