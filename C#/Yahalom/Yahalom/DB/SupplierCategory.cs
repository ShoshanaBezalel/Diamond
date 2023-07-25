using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class SupplierCategory
    {
        public SupplierCategory()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int IdCategory { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
