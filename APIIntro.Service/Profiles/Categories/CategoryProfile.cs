using APIIntro.Service.Dtos.Categories;
using APIIntro.Core.Entities;
using AutoMapper;
using APIIntro.Service.Dtos.Products;

namespace APIIntro.Profiles.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ProductPostDto, Category>();
            CreateMap<ProductUpdateDto, Category>();
            CreateMap<Category,ProductGetDto>();
        }
    }
}
