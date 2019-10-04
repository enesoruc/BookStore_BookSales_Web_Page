using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class SubCategory : BaseEntity
    {
        public SubCategory()
        {
            Books = new HashSet<Book>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        //ForeignKey
        public int CategoryID { get; set; }

        //NavProps
        public virtual Category Category { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
