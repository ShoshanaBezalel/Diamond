using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerBasicDTO:UserDTO
    {
        public bool IsGroom { get; set; }
        public DateTime? DateOfWedding { get; set; }

    }
}
