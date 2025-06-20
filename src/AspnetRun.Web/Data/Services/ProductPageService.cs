﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NetMvc.Cms.Common.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Data.Services
{
    public class ProductPageService : IProductPageService
    {
        private readonly IProductService _productAppService;
        private readonly ICategoryService _categoryAppService;
        private readonly ICartService _cartAppService;
        private readonly IWishlistService _wishlistAppService;
        private readonly ICompareService _compareAppService;

        // private readonly IMapper _mapper;
        private readonly ILogger<ProductPageService> _logger;

        public ProductPageService(IProductService productAppService, ICategoryService categoryAppService, ICartService cartAppService, IWishlistService wishlistAppService, ICompareService compareAppService, IMapper mapper, ILogger<ProductPageService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _wishlistAppService = wishlistAppService ?? throw new ArgumentNullException(nameof(wishlistAppService));
            _compareAppService = compareAppService ?? throw new ArgumentNullException(nameof(compareAppService));
            // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ListViewModel<ProductDto>> GetProducts(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                var list = await _productAppService.GetProductList();
                // var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
                var mapped = new ListViewModel<ProductDto>();
                mapped.Data = list;
                return mapped;
            }

            var listByName = await _productAppService.GetProductByName(productName);
            // var mappedByName = _mapper.Map<IEnumerable<ProductViewModel>>(listByName);
            var mappedByName = new ListViewModel<ProductDto>();
            mappedByName.Data = listByName;

            return mappedByName;
        }

        public async Task<ProductViewModel> GetProductById(int productId)
        {
            var product = await _productAppService.GetProductById(productId);
            // var mapped = _mapper.Map<ProductViewModel>(product);
            var mapped = new ProductViewModel
            {
                Data = product
            };

            return mapped;
        }

        public async Task<ProductViewModel> GetProductBySlug(string slug)
        {
            var product = await _productAppService.GetProductBySlug(slug);
            // var mapped = _mapper.Map<ProductViewModel>(product);
            var mapped = new ProductViewModel
            {
                Data = product
            };

            return mapped;
        }

        public async Task<ListViewModel<ProductDto>> GetProductByCategory(int categoryId)
        {
            var list = await _productAppService.GetProductByCategory(categoryId);
            // var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            var mapped = new ListViewModel<ProductDto>
            {
                Data = list
            };

            return mapped;
        }

        public async Task<ListViewModel<CategoryDto>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            // var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            var mapped = new ListViewModel<CategoryDto>
            {
                Data = list
            };  
            
            return mapped;
        }

        public async Task AddToCart(string userName, int productId)
        {
            await _cartAppService.AddItem(userName, productId);
        }

        public async Task AddToWishlist(string userName, int productId)
        {
            await _wishlistAppService.AddItem(userName, productId);
        }

        public async Task AddToCompare(string userName, int productId)
        {
            await _compareAppService.AddItem(userName, productId);
        }

        public async Task RemoveToCart(int cartdId, int cartItemId)
        {
            await _cartAppService.RemoveItem(cartdId, cartItemId);
        }
    }
}