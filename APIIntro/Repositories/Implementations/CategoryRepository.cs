using APIIntro.Contexts;
using APIIntro.Entities;
using APIIntro.Repositories.Interfaces;

namespace APIIntro.Repositories.Implementations
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository 
    {
        private readonly ApiDbContext _context;

        public CategoryRepository(ApiDbContext context):base(context)
        {
          
        }

    }
}
