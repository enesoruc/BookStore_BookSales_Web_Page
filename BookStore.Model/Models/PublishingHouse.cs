using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class PublishingHouse:BaseEntity
    {
        public PublishingHouse()
        {
            Books = new HashSet<Book>();
        }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public string AddressDetail { get; set; }


        //Nav Props
        public virtual ICollection<Book> Books { get; set; }
    }
}
 