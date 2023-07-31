using APIIntro.Core.Configurations;
using APIIntro.Core.Entities;
using APIIntro.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace APIIntro.Data.Contexts
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly();
            base.OnModelCreating(modelBuilder);
        }
    }
}
