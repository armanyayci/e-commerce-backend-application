using e_commerce_backend.Identity;
using e_commerce_backend.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_backend.Models.EntityFramework
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public IdentityDataContext()
        {
            
        }

        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
