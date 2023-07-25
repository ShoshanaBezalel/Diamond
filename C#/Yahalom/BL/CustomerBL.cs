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
    public class CustomerBL : ICustomerBL
    {

        //הזרקת תלויות בקונסטרקטור גם ל
        //DAL
        //וגם להמרה
        //(readonly = משתנה שאי אפשר לשנות את ערכו)

        private readonly YahalomContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerBL(YahalomContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // פונקציה מספר 1 הרשמת לקוח

        public BaseResult<int> CreateCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom)
        {
            try
            {
                Customer CreateNewCustomer = new Customer(FirstName, LastName, Password, Phone, Email, DateOfWedding, IsGroom);
                 var createdCustomer = _dbContext.Customers.Add(CreateNewCustomer);

                _dbContext.SaveChanges();

                return new BaseResult<int>()
                {
                    Data = createdCustomer.Entity.IdCustomer
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

        //פונקציה מספר 13 עדכון פרופיל לקוח
        public BaseResult<int> EditCustomer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom)
        {
            try
            {
                Customer customerdb = new Customer(FirstName, LastName, Password, Phone, Email, DateOfWedding, IsGroom);
                Customer EditCustomer = _dbContext.Customers.SingleOrDefault(x => x.Password.Equals(Password));
                if (EditCustomer!= null)
                {
                     if(customerdb.FirstName!=null) EditCustomer.FirstName = customerdb.FirstName;
                    if (customerdb.LastName != null) EditCustomer.LastName = customerdb.LastName;
                    if (customerdb.Password != null) EditCustomer.Password = customerdb.Password;
                    if (customerdb.Phone != null) EditCustomer.Phone = customerdb.Phone;
                    if (customerdb.Email != null) EditCustomer.Email = customerdb.Email;
                    if (customerdb.DateOfWedding != null) EditCustomer.DateOfWedding = customerdb.DateOfWedding;
                    if (customerdb.IsGroom != EditCustomer.IsGroom) EditCustomer.IsGroom = customerdb.IsGroom;
                    _dbContext.SaveChanges();

                    return new BaseResult<int>()
                    {
                        Data = EditCustomer.IdCustomer
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

        // פונקציה להחזרת התאריך של החתונה
        public BaseResult<DateTime?> getDateOfWedding(int idCustomer)
        {
            try
            {
                Customer thisCustomer = _dbContext.Customers.FirstOrDefault(x => x.IdCustomer == idCustomer);
                DateTime? dateOfWedding = thisCustomer.DateOfWedding;
                if (dateOfWedding != null)
                {
                    return new BaseResult<DateTime?>
                    {
                        Data = dateOfWedding
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                return new BaseResult<DateTime?>
                {
                    IsError = true,
                    ErrorCode = ErrorCode.Unexpected,
                    ErrorMessage = ex.Message
                };
            }
        }


    }
}
