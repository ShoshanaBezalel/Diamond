using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class GeneralCategory
    {
        public GeneralCategory()
        {
            GeneralTasks = new HashSet<GeneralTask>();
            NewPersonalTasks = new HashSet<NewPersonalTask>();
        }

        public int GeneralCategoryId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<GeneralTask> GeneralTasks { get; set; }
        public virtual ICollection<NewPersonalTask> NewPersonalTasks { get; set; }
    }
}
