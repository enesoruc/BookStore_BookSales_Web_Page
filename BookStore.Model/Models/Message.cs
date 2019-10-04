using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Message : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Detail { get; set; }

        //ForeignKey
        public int UserID { get; set; }

        //NavProps
        public User User { get; set; }
    }
}
