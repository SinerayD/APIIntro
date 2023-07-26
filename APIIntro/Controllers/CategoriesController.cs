using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIIntro.Entities; 

namespace APIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        static List<Category> categories = new List<Category>
        {
            new Category { Name = "Ipad" },
            new Category { Name = "Earpods" },
            new Category { Name = "Iphone" },
            new Category { Name = "Accessories" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(categories[0]);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            categories.Add(category);
            return Ok();
        }
    }
}
