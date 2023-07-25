using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DB
{
    public partial class SupplierCategory
    {
        public SupplierCategory()
        {
            SecondCtegories = new HashSet<SecondCtegory>();
            Suppliers = new HashSet<Supplier>();
        }

        public int IdCategory { get; set; }
        public string Category { get; set; }
        public bool? IsForGroom { get; set; }

        public virtual ICollection<SecondCtegory> SecondCtegories { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
