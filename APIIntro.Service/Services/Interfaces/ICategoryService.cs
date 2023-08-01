using APIIntro.Service.Dtos.Categories;
using APIIntro.Core.Entities;
using APIIntro.Service.Responses;

namespace APIIntro.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ApiResponse> CreateAsync(CategoryPostDto dto);
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> UpdateAsync(int id, CategoryUpdateDto dto);
        public Task<ApiResponse> RemoveAsync(int id);
    }
}
