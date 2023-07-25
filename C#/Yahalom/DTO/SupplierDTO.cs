using DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplierDTO : SupplierBasicDTO
    {
        public virtual SupplierCategory IdCategoryNavigation { get; set; }
        public virtual PlaceId IdPlaceNavigation { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}