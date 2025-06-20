﻿using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;
using AspnetRun.Application.Interfaces;
using AspnetRun.Shared.Extentions;
using Microsoft.Extensions.Logging;

namespace AspnetRun.Application.Services
{
    // NOTE : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ProductDto>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            // var mapped = ObjectMapper.Mapper.Map<List<ProductModel>>(productList.ToList());
            var mapped = productList.ToList().ToProductDtoList();
            return mapped;
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            // var mapped = ObjectMapper.Mapper.Map<ProductModel>(product);
            var mapped = product.ToProductDto();
            return mapped;
        }

        public async Task<ProductDto> GetProductBySlug(string slug)
        {
            var product = await _productRepository.GetProductBySlug(slug);
            // var mapped = ObjectMapper.Mapper.Map<ProductModel>(product);
            var mapped = product.ToProductDto();

            return mapped;
        }

        public async Task<List<ProductDto>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            // var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            var mapped = productList.ToList().ToProductDtoList();
            return mapped;
        }

        public async Task<List<ProductDto>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            // var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductModel>>(productList);
            var mapped = productList.ToList().ToProductDtoList();
            return mapped;
        }

        public async Task<ProductDto> Create(ProductDto productModel)
        {
            await ValidateProductIfExist(productModel);

            // var mappedEntity = ObjectMapper.Mapper.Map<Product>(productModel);
            var mappedEntity = productModel.ToProductEntity();

            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            // var newMappedEntity = ObjectMapper.Mapper.Map<ProductModel>(newEntity);
            var newMappedEntity = newEntity.ToProductDto();
            return newMappedEntity;
        }

        public async Task Update(ProductDto productModel)
        {
            ValidateProductIfNotExist(productModel);
            
            var editProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (editProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            // ObjectMapper.Mapper.Map<ProductModel, Product>(productModel, editProduct);

            editProduct = productModel.ToProductEntity();

            await _productRepository.UpdateAsync(editProduct);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(ProductDto productModel)
        {
            ValidateProductIfNotExist(productModel);
            var deletedProduct = await _productRepository.GetByIdAsync(productModel.Id);
            if (deletedProduct == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _productRepository.DeleteAsync(deletedProduct);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateProductIfExist(ProductDto productModel)
        {
            var existingEntity = await _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{productModel.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(ProductDto productModel)
        {
            var existingEntity = _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{productModel.ToString()} with this id is not exists");
        }        
    }
}
