using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Responses
{
    public enum ErrorCode
    {
        Success = 0,
        NotExistUser = 1,
        WrongPassword = 2,
        Unexpected = 99
    }
}
