using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Responses
{
    public class LoginRes
    {
        public bool IsAuth { get; set; }
        public UserDTO User { get; set; }
    }
}
