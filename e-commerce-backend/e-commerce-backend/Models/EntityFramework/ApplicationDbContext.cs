using e_commerce_backend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_backend.Models.EntityFramework
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }


    }
}
