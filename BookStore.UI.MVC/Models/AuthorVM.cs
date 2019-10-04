using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class AuthorVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Detail { get; set; }
        public string ImagePath { get; set; }
    }
}