﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using AspnetRun.Shared.Extentions;
using Microsoft.Extensions.Logging;

namespace AspnetRun.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CartService> _logger;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, ILogger<CartService> logger)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartDto> GetCartByUserName(string userName)
        {
            var cart = await GetExistingOrCreateNewCart(userName);
            var cartModel = cart.ToCartDto();

            if (cart.Items.Any(c => c.Product == null)) // If product can not loaded from razor page, we apply manuel mapping.
            {
                cartModel.Items.Clear();
                foreach (var item in cart.Items)
                {
                    var cartItemModel = item.ToCartItemDto();
                    var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                    var productModel = product.ToProductDto();
                    cartItemModel.Product = productModel;
                    cartModel.Items.Add(cartItemModel);
                }
            }

            return cartModel;
        }

        public async Task AddItem(string userName, int productId)
        {
            var cart = await GetExistingOrCreateNewCart(userName);

            var product = await _productRepository.GetByIdAsync(productId);
            cart.AddItem(productId, unitPrice:product.UnitPrice);
            await _cartRepository.UpdateAsync(cart);
        }

        public async Task RemoveItem(int cartId, int cartItemId)
        {
            var spec = new CartWithItemsSpecification(cartId);
            var cart = (await _cartRepository.GetAsync(spec)).FirstOrDefault();
            cart.RemoveItem(cartItemId);
            await _cartRepository.UpdateAsync(cart);
        }

        private async Task<Cart> GetExistingOrCreateNewCart(string userName)
        {
            var cart = await _cartRepository.GetByUserNameAsync(userName);
            if (cart != null)
                return cart;

            // if it is first attempt create new
            var newCart = new Cart
            {
                UserName = userName
            };

            await _cartRepository.AddAsync(newCart);
            return newCart;
        }

        public async Task ClearCart(string userName)
        {
            var cart = await _cartRepository.GetByUserNameAsync(userName);
            if (cart == null)
                throw new ApplicationException("Submitted order should have cart");

            cart.ClearItems();

            await _cartRepository.UpdateAsync(cart);
        }
    }
}
