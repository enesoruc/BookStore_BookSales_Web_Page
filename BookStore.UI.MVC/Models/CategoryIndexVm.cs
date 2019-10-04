using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class CategoryIndexVM
    {
        public List<Book> NewBooks { get; set; }
        public List<Book> MostSales { get; set; }
    }
}