using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Web.Data.Services
{
    public class CheckOutPageService : ICheckOutPageService
    {
        private readonly ICartService _cartAppService;
        private readonly IOrderService _orderAppService;
        // private readonly IMapper _mapper;
        private readonly ILogger<CheckOutPageService> _logger;

        public CheckOutPageService(ICartService cartAppService, IOrderService orderAppService, IMapper mapper, ILogger<CheckOutPageService> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartViewModel> GetCart(string userName)
        {
            var cart = await _cartAppService.GetCartByUserName(userName);
            // var mapped = _mapper.Map<CartViewModel>(cart);
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
        
        public async Task CheckOut(OrderViewModel order, string userName)
        {            
            var cart = await GetCart(userName);
            TransformCartItemToOrderItem(order, cart);
            SetUserNameOfOrder(order, userName);
            
            // var mappedOrderModel = _mapper.Map<OrderDto>(order);
            var mappedOrderModel = new OrderDto
            {
                UserName = order.UserName,
                GrandTotal = order.GrandTotal,
                Items = order.Items.Select(item => new OrderItemDto
                {
                    Color = item.Data.Color,
                    Quantity = item.Data.Quantity,
                    UnitPrice = item.Data.UnitPrice,
                    TotalPrice = item.Data.TotalPrice,
                    ProductId = item.Data.ProductId,
                    Product = item.Data.Product
                }).ToList()
            };

            await _orderAppService.CheckOut(mappedOrderModel);

            await _cartAppService.ClearCart(userName);
        }

        private void TransformCartItemToOrderItem(OrderViewModel order, CartViewModel cart)
        {
            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(
                    new OrderItemViewModel
                    {
                        Data = new OrderItemDto
                        {
                            ProductId = cartItem.Data.ProductId,
                            Quantity = cartItem.Data.Quantity,
                            UnitPrice = cartItem.Data.UnitPrice,
                            TotalPrice = cartItem.Data.TotalPrice,
                            Color = cartItem.Data.Color,
                            Product = cartItem.Data.Product
                        }
                    });
            }
        }

        private void SetUserNameOfOrder(OrderViewModel order, string userName)
        {
            order.UserName = userName;
        }

    }
}
