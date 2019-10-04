using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Language:BaseEntity
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }

        //Nav Props
        public virtual ICollection<Book> Books { get; set; }
    }
}
