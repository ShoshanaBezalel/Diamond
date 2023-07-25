using BL;
using DTO;
using DTO.Requests;
using DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yahalom.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthBL _authBL;

        public AuthController(IAuthBL authBL)
        {
            _authBL = authBL;
        }
        // פונקציה מספר 3 - לוגין
        [HttpPost]
        public BaseResult<LoginRes> Login(LoginReq request)
        {
            var res = _authBL.Login(request);
            return res;
        }
    }
}
