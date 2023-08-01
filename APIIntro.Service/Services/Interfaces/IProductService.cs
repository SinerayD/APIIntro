using APIIntro.Service.Dtos.Products;
using APIIntro.Service.Responses;


namespace APIIntro.Service.Services.Interfaces
{
    public interface IProductService
    {
        public  Task<ApiResponse> CreateAsync(ProductPostDto dto);
        public Task<ApiResponse> GetAllAsync();
        public Task<ApiResponse> GetAsync(int id);
        public Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto);
        public Task<ApiResponse> RemoveAsync(int id);
    }
}
