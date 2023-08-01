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
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
