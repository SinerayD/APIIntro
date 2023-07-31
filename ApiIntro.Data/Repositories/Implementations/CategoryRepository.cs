using APIIntro.Core.Entities;
using APIIntro.Data.Contexts;
using APIIntro.Core.Repositories.Interfaces;
using APIIntro.Repositories.Implementations;

namespace APIIntro.Data.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApiDbContext _context;

        public CategoryRepository(ApiDbContext context) : base(context)
        {
          
        }

    }
}
