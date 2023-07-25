using DAL.DB;
using DTO;
using DTO.Requests;
using DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AuthBL : IAuthBL
    {
        private readonly YahalomContext _dbContext;

        public AuthBL(YahalomContext dbContext)
        {
            _dbContext = dbContext;
        }

        //   פונקציה מספר 3 - לוגין
        public BaseResult<LoginRes> Login(LoginReq request)
        {
            try
            {
                UserDTO existUser = null;
                
                if (request.Role == Role.Customer)
                {
                    Customer customer = _dbContext.Customers.FirstOrDefault(c => c.Password.Equals(request.Password));
                    
                    if (customer is not null)
                    {
                        existUser = DTOConvertor.ConvertToDTO(customer);
                    }
                }
                else
                {
                    
                    Supplier supplier = _dbContext.Suppliers.FirstOrDefault(c => c.Password.Equals(request.Password));

                    if (supplier is not null)
                    {
                        existUser = DTOConvertor.ConvertToDTO(supplier);
                    }
                }

                return GetLoginUserResult(request, existUser);
            }
            catch (Exception ex)
            {
                return new BaseResult<LoginRes>()
                {
                    IsError = true,
                    ErrorMessage = ex.Message,
                    ErrorCode = ErrorCode.Unexpected
                };
            }
        }

        private BaseResult<LoginRes> GetLoginUserResult(LoginReq request, UserDTO user)
        {
            // not exist user
            if (user is null)
            {
                return new BaseResult<LoginRes>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.NotExistUser,
                    ErrorMessage = "user does not exist",
                    Data = new LoginRes() { IsAuth = false }
                };
            }

            // wrong password
            if (user.Password is null ||!user.Password.Equals(request.Password))
            {
                return new BaseResult<LoginRes>()
                {
                    IsError = true,
                    ErrorCode = ErrorCode.WrongPassword,
                    ErrorMessage = "wrong password",
                    Data = new LoginRes() { IsAuth = false }
                };
            }

            // end successfully
            return new BaseResult<LoginRes>()
            {
                Data = new LoginRes() { IsAuth = true,User=user }
            };
        }
    }
}
