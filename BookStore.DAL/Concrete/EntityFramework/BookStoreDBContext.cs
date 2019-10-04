using BookStore.DAL.Concrete.EntityFramework.Mappings;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Concrete.EntityFramework
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
            : base("Server=.;Database=BookStoreDB;Trusted_Connection=True")
        {
            Database.SetInitializer<BookStoreDBContext>(new CreateDatabaseIfNotExists<BookStoreDBContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(a => a.PropertyType == typeof(string))//tipi string olan propertyler zorunlu
                .Configure(a => a.IsRequired());

            modelBuilder.Properties()
                .Where(a => a.PropertyType == typeof(DateTime))
                .Configure(a => a.HasColumnType("datetime"));

            modelBuilder.Properties()
                           .Where(a => a.PropertyType == typeof(decimal))
                           .Configure(a => a.HasPrecision(4, 2));

            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new BookMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CityMapping());
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new DistrictMapping());
            modelBuilder.Configurations.Add(new LanguageMapping());
            modelBuilder.Configurations.Add(new OrderDetailMapping());
            modelBuilder.Configurations.Add(new OrderMapping());
            modelBuilder.Configurations.Add(new PublishingHouseMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserRoleMapping());
            modelBuilder.Configurations.Add(new AuthorMapping());
            modelBuilder.Configurations.Add(new MessageMapping());
            modelBuilder.Configurations.Add(new SubCategoryMapping());
            modelBuilder.Configurations.Add(new CampaignMapping());
            modelBuilder.Configurations.Add(new CommentMapping());
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
