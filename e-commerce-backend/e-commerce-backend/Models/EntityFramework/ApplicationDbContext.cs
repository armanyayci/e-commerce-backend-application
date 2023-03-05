using e_commerce_backend.Identity;
using e_commerce_backend.Models.DTO;
using e_commerce_backend.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace e_commerce_backend.Models.EntityFramework
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>()
                .HasOne(s => s.Category)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.Category_Id);

            base.OnModelCreating(modelBuilder);
        }

    }
}
