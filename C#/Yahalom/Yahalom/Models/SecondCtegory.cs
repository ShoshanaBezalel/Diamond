using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.Models
{
    public partial class SecondCtegory
    {
        public SecondCtegory()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int IdSecondCtegory { get; set; }
        public string DescriptionSecondCtegory { get; set; }
        public int? IdCategoryLinking { get; set; }

        public virtual SupplierCategory IdCategoryLinkingNavigation { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
