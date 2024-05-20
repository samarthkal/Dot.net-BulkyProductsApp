using BulkyProductsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyProductsApp.Data
{
    public class AppDbContext:DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }    
        

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="action",DisplayOrder=1},
                 new Category { Id = 2, Name = "histroy", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "scify", DisplayOrder = 3 },
                  new Category { Id = 4, Name = "drama", DisplayOrder = 4 }

                );
        }
    }
}
