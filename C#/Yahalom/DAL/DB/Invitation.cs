using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DB
{
    public partial class Invitation
    {
        public Invitation(DateTime? DateOfInvitation, int? FinalPrice, string Location, int? StatusId, DateTime? From, DateTime? To,
       int? IdCustomer,int? IdSuplier)
        {
            this.DateOfInvitation = DateOfInvitation;
            this.FinalPrice = FinalPrice;
            this.Location = Location;
            this.StatusId = StatusId;
            this.From = From;
            this.To = To;
            this.IdCustomer = IdCustomer;
            this.IdSuplier = IdSuplier;

            //j

        }
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
