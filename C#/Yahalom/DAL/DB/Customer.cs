using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.DB
{
    public partial class Customer
    {
        public Customer()
        {
            Invitations = new HashSet<Invitation>();
            MyTasks = new HashSet<MyTask>();
        }
        public Customer(string FirstName, string LastName, string Password, int? Phone, string Email, DateTime? DateOfWedding, bool IsGroom)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfWedding = DateOfWedding;
            this.IsGroom = IsGroom;

        }
        public int IdCustomer { get; set; }
        public bool IsGroom { get; set; }
        public DateTime? DateOfWedding { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Customer: name: {FirstName}\nEmail: {Email}\nPhone: {Phone}";
        }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<MyTask> MyTasks { get; set; }


    }
}
