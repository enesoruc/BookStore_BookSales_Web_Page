using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class CartItem
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}