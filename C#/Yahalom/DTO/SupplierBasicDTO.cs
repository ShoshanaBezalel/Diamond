using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplierBasicDTO:UserDTO
    {
        public int? IdCategory { get; set; }
        public int? IdPlace { get; set; }
        public string AboutMe { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceUntill { get; set; }
        public int IdSuplier { get; set; }
    }
}
