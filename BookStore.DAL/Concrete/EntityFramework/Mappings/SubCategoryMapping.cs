using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework.Mappings
{
    public class SubCategoryMapping : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMapping()
        {
            Property(a => a.Name).HasMaxLength(30);
            Property(a => a.Description).HasMaxLength(1000);
        }
    }
}
