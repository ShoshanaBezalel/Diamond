using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DB
{
    public partial class Supplier
    {
        public Supplier()
        {
            Invitations = new HashSet<Invitation>();
        }
        public Supplier(string FirstName, string LastName, string Password, int? Phone, string Email, string BusinessName,
            int? IdCategory, int? IdSecondSupplierCategory, int? PriceFrom, int? PriceUntill, string AboutMe, int? PlaceId)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.Phone = Phone;
            this.Email = Email;
            this.BusinessName = BusinessName;
            this.IdCategory = IdCategory;
            this.IdSecondSupplierCategory = IdSecondSupplierCategory;
            this.PriceFrom = PriceFrom;
            this.PriceUntill = PriceUntill;
            this.AboutMe = AboutMe;
            this.IdPlace = PlaceId;
        }

        public int? IdCategory { get; set; }
        public int? IdPlace { get; set; }
        public string AboutMe { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceUntill { get; set; }
        public int IdSuplier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public int? IdSecondSupplierCategory { get; set; }
        public string BusinessName { get; set; }

        public virtual SupplierCategory IdCategoryNavigation { get; set; }
        public virtual PlaceId IdPlaceNavigation { get; set; }
        public virtual SecondCtegory IdSecondSupplierCategoryNavigation { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
