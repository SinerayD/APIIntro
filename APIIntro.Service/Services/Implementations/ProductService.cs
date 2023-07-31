using APIIntro.Core.Entities;
using APIIntro.Core.Repositories;
using APIIntro.Core.Repositories.Interfaces;
using APIIntro.Service.Dtos.Products;
using APIIntro.Service.Extensions;
using APIIntro.Service.Responses;
using APIIntro.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace APIIntro.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment env, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _env = env;
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse> CreateAsync(ProductPostDto dto)
        {
            if (!await _categoryRepository.IsExist(x => x.Id == dto.CategoryId))
            {
                return new ApiResponse { StatusCode = 404, Message = "Category id is invalid" };
            }

            Product product = _mapper.Map<Product>(dto);
            product.Image = dto.File.SaveFile(_env.WebRootPath, "assets/images");
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();

            return new ApiResponse { StatusCode = 201 };
        }

        public Task<ApiResponse> CreateAsync(Dtos.Categories.ProductPostDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var query = await _productRepository.GetAllAsync(x => !x.IsDeleted);
            IEnumerable<ProductGetDto> productGetDtos = await query
                .Select(x => new ProductGetDto { Image = x.Image, CategoryId = x.CategoryId, Name = x.Name, Price = x.Price })
                .ToListAsync();

            return new ApiResponse { Items = productGetDtos, StatusCode = 200 };
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var query = await _productRepository.GetAllAsync(x => !x.IsDeleted);
            List<ProductGetDto> productGetDtos = await query
                .Select(x => new ProductGetDto { Image = x.Image, CategoryId = x.CategoryId, Name = x.Name, Price = x.Price })
                .ToListAsync();

            return new ApiResponse { Items = productGetDtos, StatusCode = 200 };
        }

        Task<ApiResponse> IProductService.RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ApiResponse> IProductService.UpdateAsync(int id, Dtos.Categories.ProductPostDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

