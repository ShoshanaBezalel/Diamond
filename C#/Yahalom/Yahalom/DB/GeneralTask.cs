using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class GeneralTask
    {
        public GeneralTask()
        {
            MyTasks = new HashSet<MyTask>();
        }

        public int? GeneralCategoryId { get; set; }
        public string MissionDescription { get; set; }
        public int GeneralTasksId { get; set; }
        public int? SecondCategoryId { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual SecondCategory SecondCategory { get; set; }
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
