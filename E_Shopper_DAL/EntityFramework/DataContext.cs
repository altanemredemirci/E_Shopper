using E_Shopper_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shopper_DAL.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        public DataContext():base("DataContext")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Categories)
                .WithMany(c => c.Brands)
                .Map(cs =>
                {
                    cs.MapLeftKey("CategoryId");
                    cs.MapRightKey("BrandId");
                    cs.ToTable("CategoryBrand");
                });
        }

    }
}
