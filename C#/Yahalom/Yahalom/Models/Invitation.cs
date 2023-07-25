using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.Models
{
    public partial class Invitation
    {
        public int IdInvitation { get; set; }
        public DateTime? DateOfInvitation { get; set; }
        public int? FinalPrice { get; set; }
        public string Location { get; set; }
        public int? StatusId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int? IdSuplier { get; set; }
        public int? IdCustomer { get; set; }
        public bool? IsPaid { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Supplier IdSuplierNavigation { get; set; }
        public virtual Status Status { get; set; }
    }
}
