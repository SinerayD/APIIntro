using APIIntro.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIIntro.Contexts
{
    public class ApiDbContext:DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
