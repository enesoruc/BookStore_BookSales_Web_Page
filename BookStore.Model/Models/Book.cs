using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Book : BaseEntity
    {
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Comments = new HashSet<Comment>();
        }

        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime YearOfPrinting { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

        //Foreign Key
        public int PublishingHouseID { get; set; }
        public int AuthorID { get; set; }
        public int SubCategoryID { get; set; }
        public int LanguageID { get; set; }

        //Nav Props
        public virtual Language Language { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Author Author { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
