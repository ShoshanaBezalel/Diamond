using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class Supplier
    {
        public Supplier()
        {
            Invitations = new HashSet<Invitation>();
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

        public virtual SupplierCategory IdCategoryNavigation { get; set; }
        public virtual PlaceId IdPlaceNavigation { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
