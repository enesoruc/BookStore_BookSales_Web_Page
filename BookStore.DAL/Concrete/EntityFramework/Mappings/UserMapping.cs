using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.EMail).HasMaxLength(255);
            Property(a => a.FirstName).HasMaxLength(30);
            Property(a => a.LastName).HasMaxLength(30);
            Property(a => a.PhoneNumber).HasColumnType("char").HasMaxLength(12);
            Property(a => a.Password).HasMaxLength(15);
            Property(a=>a.UserName).HasMaxLength(15);
        }
    }
}
