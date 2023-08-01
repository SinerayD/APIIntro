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
using System.Xml.Linq;

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


        public async Task<ApiResponse> GetAllAsync()
        {
            var query = await _productRepository.GetAllAsync(x => !x.IsDeleted,"Category");
            IEnumerable<ProductGetDto> productGetDtos = await query
                .Select(x => new ProductGetDto { Image = x.Image, CategoryId = x.CategoryId, Name = x.Name, Price = x.Price, 
                    CategoryName=x.Category.Name })
                .ToListAsync();

            return new ApiResponse { Items = productGetDtos, StatusCode = 200 };
        }

        public async Task<ApiResponse> GetAsync(int id)
        {
            Product product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id, "Category");

            if (product == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "Product not found" };
            }

            ProductGetDto productGet = _mapper.Map<ProductGetDto>(product);
            productGet.CategoryName = product.Category.Name;

            return new ApiResponse { StatusCode = 200, Items = productGet };
        }

        public async Task<ApiResponse> RemoveAsync(int id)
        {
            Product product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (product == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "Product not found" };
            }

            product.IsDeleted = true;
            await _productRepository.Update(product);
            await _productRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }

        public async Task<ApiResponse> UpdateAsync(int id, ProductUpdateDto dto)
        {
            Product product = await _productRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (product == null)
            {
                return new ApiResponse { StatusCode = 404, Message = "Product not found" };
            }

            product.Name=dto.Name;
            product.Price = dto.Price;
            product.CategoryId=dto.CategoryId;
            product.Image = dto.File == null ? product.Image : dto.File.SaveFile(_env.WebRootPath, "assets/images");
            await _productRepository.Update(product);
            await _productRepository.SaveAsync();
            return new ApiResponse { StatusCode = 204 };
        }

    }
}

