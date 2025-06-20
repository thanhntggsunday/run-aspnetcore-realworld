﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;

namespace AspnetRun.Web.Data.Services
{
    public class CartComponentService : ICartComponentService
    {
        private readonly ICartService _cartAppService;

        // private readonly IMapper _mapper;
        private readonly ILogger<CartComponentService> _logger;

        public CartComponentService(ICartService cartAppService, IMapper mapper, ILogger<CartComponentService> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartViewModel> GetCart(string userName)
        {
            var cart = await _cartAppService.GetCartByUserName(userName);
            var mapped = new CartViewModel
            {
                UserName = userName,
                Items = new List<CartItemViewModel>()
            };

            foreach (var item in cart.Items)
            {
                var cartItemViewModel = new CartItemViewModel
                {
                    Data = item
                };

                mapped.Items.Add(cartItemViewModel);
            }

            return mapped;
        }

        public async Task AddItem(string userName, int productId)
        {
            await _cartAppService.AddItem(userName, productId);
        }

        public async Task RemoveItem(int cartId, int cartItemId)
        {
            await _cartAppService.RemoveItem(cartId, cartItemId);
        }
    }
}