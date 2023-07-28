using Microsoft.AspNetCore.Mvc;
using APIIntro.Entities;
using APIIntro.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using APIIntro.Dtos.Categories;
using AutoMapper;

namespace APIIntro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto)
        {
            if (_context.Categories.Any(X => X.Name.Trim().ToLower() == dto.Name.Trim().ToLower()))
            {
                return StatusCode(400, new { description = $"{dto.Name} Alredy exists" });
            }
            Category category = _mapper.Map<Category>(dto);
       

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
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
        {
            if (_context.Categories.Any(X => X.Name.Trim().ToLower() == dto.Name.Trim().ToLower() && X.Id != id))
            {
                return StatusCode(400, new { description = $"{dto.Name} Already exists" });
            }
            Category? updated = await _context.Categories
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (updated == null)
            {
                return StatusCode(404, new { description = "Category is null" });
            }

            updated = _mapper.Map<Category>(dto);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }
       // private Category Map(CategoryPostDto dto)
       // {
         //   return new Category { Name = dto.Name, Description = dto.Description };
       // }
    }
}