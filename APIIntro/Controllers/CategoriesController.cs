using Microsoft.AspNetCore.Mvc;
using APIIntro.Entities;
using APIIntro.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using APIIntro.Dtos.Categories;
using AutoMapper;
using APIIntro.Repositories;

namespace APIIntro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CategoryRepository _repository;

        public CategoriesController(IMapper mapper, CategoryRepository repository)
        {
            _mapper = mapper;
           _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IQueryable<Category> query = await _repository.GetAllAsync();

            List<CategoryGetDto> categories = new List<CategoryGetDto>();

            categories= await query.Select(x=> new CategoryGetDto { Name=x.Name}).ToListAsync();  
            
            return StatusCode(200, categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category? category = await _repository.GetByIdAsync(id);
               

            if (category == null)
            {
                return StatusCode(404);
            }
            CategoryGetDto getDto=_mapper.Map<CategoryGetDto>(category);

            return StatusCode(200, getDto);

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto)
        {
            if (await _repository.IsExist(dto.Name))
            {
                return StatusCode(400, new { description = $"{dto.Name} Alredy exists" });
            }
            Category category = _mapper.Map<Category>(dto);


            await _repository.AddAsync(category);
            await _repository.SaveAsync();
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