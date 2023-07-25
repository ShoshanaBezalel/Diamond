using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplierCategoryDTO
    {
        public SupplierCategoryDTO()
        {

        }

        public int IdCategory { get; set; }
        public string Category { get; set; }
        public bool isForGroom { get; set; }
    }
}
