using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class Status
    {
        public Status()
        {
            Invitations = new HashSet<Invitation>();
            MyTasks = new HashSet<MyTask>();
        }

        public int StatusId { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
