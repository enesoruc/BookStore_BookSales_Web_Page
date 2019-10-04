using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class AccountVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string RePassword { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}