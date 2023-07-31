namespace APIIntro.Service.Dtos.Categories
{
    public record ProductPostDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
