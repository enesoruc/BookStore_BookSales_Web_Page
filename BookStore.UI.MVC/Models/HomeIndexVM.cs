using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.UI.MVC.Models
{
    public class HomeIndexVM
    {
        public Author AuthorOfTheWeek { get; set; }
        public List<Book> AuthorBooks { get; set; }
        public List<Author> AuthorsOfTheMonth { get; set; }
        public List<PublishingHouse> PublishingHousesOfTheMonth { get; set; }
        public PublishingHouse PublishingHouseOfTheWeek { get; set; }
        public List<Book> PublishingHouseOfTheWeekBooks { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }
}