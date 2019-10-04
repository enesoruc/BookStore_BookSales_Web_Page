using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
   public  class MessageMapping : EntityTypeConfiguration<Message>
    {
        public MessageMapping()
        {
            Property(a => a.FirstName).HasMaxLength(15);
            Property(a => a.LastName).HasMaxLength(15);
            Property(a => a.Subject).HasMaxLength(20);
            Property(a => a.Email).HasMaxLength(255);
            Property(a => a.Detail).HasMaxLength(500);
        }
    }
}
