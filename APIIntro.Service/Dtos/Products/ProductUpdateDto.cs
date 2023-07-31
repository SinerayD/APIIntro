using Microsoft.AspNetCore.Http;

namespace APIIntro.Service.Dtos.Products
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public IFormFile File { get; set; }
        public int CategoryId { get; set; }
    }
}
