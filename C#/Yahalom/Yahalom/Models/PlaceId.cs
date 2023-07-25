using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.Models
{
    public partial class PlaceId
    {
        public PlaceId()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int PlaceId1 { get; set; }
        public string Place { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
