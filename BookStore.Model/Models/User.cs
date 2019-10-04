using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Addresses = new HashSet<Address>();
            Comments = new HashSet<Comment>();
            Messages = new HashSet<Message>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string UserName { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }

        //Foreign Key
        public int UserRoleID { get; set; }

        //Nav Props
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
