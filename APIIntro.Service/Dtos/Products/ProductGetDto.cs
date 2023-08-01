namespace APIIntro.Service.Dtos.Products
{
    public class ProductGetDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }    
    }
}
