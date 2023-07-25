using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class NewPersonalTask
    {
        public NewPersonalTask()
        {
            MyTasks = new HashSet<MyTask>();
        }

        public int NewPersonalTasksId { get; set; }
        public int? GeneralCategoryId { get; set; }
        public string MissionDescription { get; set; }
        public int? SecondCategoryId { get; set; }

        public virtual GeneralCategory GeneralCategory { get; set; }
        public virtual SecondCategory SecondCategory { get; set; }
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
