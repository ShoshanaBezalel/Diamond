using System;
using System.Collections.Generic;

#nullable disable

namespace Yahalom.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Invitations = new HashSet<Invitation>();
            MyTasks = new HashSet<MyTask>();
        }

        public int IdCustomer { get; set; }
        public string GroomOrBride { get; set; }
        public DateTime? DateOfWedding { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<MyTask> MyTasks { get; set; }
    }
}
