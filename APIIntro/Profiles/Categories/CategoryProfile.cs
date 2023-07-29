using APIIntro.Dtos.Categories;
using APIIntro.Entities;
using AutoMapper;

namespace APIIntro.Profiles.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category,CategoryGetDto>();
        }
    }
}
