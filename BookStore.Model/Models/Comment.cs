using BookStore.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class Comment : BaseEntity
    {
        public string Subject { get; set; }
        public string Detail { get; set; }

        //ForeignKey
        public int UserID { get; set; }
        public int BookID { get; set; }

        //NavProps
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
