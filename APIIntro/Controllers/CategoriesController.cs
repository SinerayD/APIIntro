using Microsoft.AspNetCore.Mvc;
using APIIntro.Entities;
using APIIntro.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CategoriesController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return StatusCode(200, categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category? category = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return StatusCode(404, category);
            }
            return StatusCode(200, category);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category)
        {
            if (_context.Categories.Any(X => X.Name.Trim().ToLower() == category.Name.Trim().ToLower()))
            {
                return StatusCode(400, new { description = $"{category.Name} Alredy exists" });
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(201, category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Category? category = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            if (category == null)
            {
                return StatusCode(404);
            }
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id, [FromBody] Category category)
        {
            if (_context.Categories.Any(X => X.Name.Trim().ToLower() == category.Name.Trim().ToLower() && X.Id!=id))
            {
                return StatusCode(400, new { description = $"{category.Name} Already exists" });
            }
            Category? updated = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(updated == null)
            {
                return StatusCode(404, new { description = "Category is null" } );
            }
            updated.Name = category.Name;
            await _context.SaveChangesAsync();
            return StatusCode(204);

        }
    }
}