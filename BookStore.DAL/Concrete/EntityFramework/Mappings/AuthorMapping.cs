using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class AuthorMapping : EntityTypeConfiguration<Author>
    {
        public AuthorMapping()
        {
            Property(a => a.FirstName).HasMaxLength(15);
            Property(a => a.LastName).HasMaxLength(15);
            Property(a => a.Detail).HasMaxLength(1000);
        }
    }
}
