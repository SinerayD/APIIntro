using APIIntro.Service.Dtos.Categories;
using APIIntro.Core.Entities;
using APIIntro.Service.Responses;

namespace APIIntro.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<ApiResponse> CreateAsync(ProductPostDto dto);
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> UpdateAsync(int id,ProductUpdateDto dto);
        public Task<ApiResponse> RemoveAsync(int id);
    }
}
