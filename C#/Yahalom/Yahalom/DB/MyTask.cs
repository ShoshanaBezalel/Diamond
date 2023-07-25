using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class MyTask
    {
        public int MyTasksId { get; set; }
        public int? IdTasks { get; set; }
        public int? StatusId { get; set; }
        public string Remarks { get; set; }
        public int? SupplierId { get; set; }
        public int? IdCustomer { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual NewPersonalTask IdTasks1 { get; set; }
        public virtual GeneralTask IdTasksNavigation { get; set; }
        public virtual Status Status { get; set; }
    }
}
