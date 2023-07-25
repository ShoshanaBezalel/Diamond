using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.Models
{
    public partial class MyTask
    {
        public int MyTasksId { get; set; }
        public string MissionDescription { get; set; }
        public int? StatusId { get; set; }
        public string Remarks { get; set; }
        public int? SupplierId { get; set; }
        public int? IdCustomer { get; set; }
        public bool? IsToWeddingDay { get; set; }
        public string CategoryForTask { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Status Status { get; set; }
    }
}
