using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class SecondCategory
    {
        public SecondCategory()
        {
            GeneralTasks = new HashSet<GeneralTask>();
            NewPersonalTasks = new HashSet<NewPersonalTask>();
        }

        public int SecondCategoryId { get; set; }
        public string Details { get; set; }

        public virtual ICollection<GeneralTask> GeneralTasks { get; set; }
        public virtual ICollection<NewPersonalTask> NewPersonalTasks { get; set; }
    }
}
