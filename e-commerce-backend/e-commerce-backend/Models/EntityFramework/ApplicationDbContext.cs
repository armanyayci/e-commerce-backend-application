using e_commerce_backend.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_backend.Models.EntityFramework
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Category)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.Category_Id)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
