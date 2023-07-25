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
    //פונקציה מספר 3 - לוגין
    public interface IAuthBL
    {
        BaseResult<LoginRes> Login(LoginReq request);
    }
}
