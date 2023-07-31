using APIIntro.Core.Entities;
using APIIntro.Core.Repositories;
using APIIntro.Data.Contexts;
using APIIntro.Repositories.Implementations;

namespace APIIntro.Data.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiDbContext context) : base(context)
        {
        }
    }

}
