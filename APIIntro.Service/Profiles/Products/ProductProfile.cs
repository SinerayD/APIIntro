using APIIntro.Core.Entities;
using APIIntro.Service.Dtos.Categories;
using AutoMapper;


namespace APIIntro.Service.Profiles.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductPostDto,Product>();
        }
    }
}
