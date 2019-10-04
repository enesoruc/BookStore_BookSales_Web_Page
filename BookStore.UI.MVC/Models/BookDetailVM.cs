using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class BookDetailVM
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfPage { get; set; }
        public int Discount { get; set; }
        public string Author { get; set; }
        public int AuthorID { get; set; }
        public string PublishingHouse { get; set; }
        public int PublishingHouseID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int SubCategoryID { get; set; }
    }
}