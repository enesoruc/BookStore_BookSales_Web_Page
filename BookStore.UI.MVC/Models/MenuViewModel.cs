using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class MenuViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }//campaigns
    }
}