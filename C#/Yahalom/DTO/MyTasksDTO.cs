using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class MyTasksDTO
    {

        public int MyTasksId { get; set; }
        public int? StatusId { get; set; }
        public string Remarks { get; set; }
        public int? SupplierId { get; set; }
        public int? IdCustomer { get; set; }
        public bool? IsToWeddingDay { get; set; }
        public string CategoryForTask { get; set; }
        public string MissionDescription { get; set; }

    }
}
