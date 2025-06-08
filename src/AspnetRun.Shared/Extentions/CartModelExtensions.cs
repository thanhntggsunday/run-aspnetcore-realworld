using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Shared.Extentions
{
    public static class CartModelExtensions
    {
        public static CartDto ToCartDto(this Cart cart)
        {
            if (cart == null) return null;
            return new CartDto
            {
                Id = cart.Id,
                UserName = cart.UserName,
                Items = cart.Items?.Select(i => i.ToCartItemDto()).ToList() ?? new List<CartItemDto>(),
                // TotalPrice = cart.TotalPrice
            };
        }

        public static Cart ToCartEntity(this CartDto cartModel)
        {
            if (cartModel == null) return null;
            return new Cart
            {
                Id = cartModel.Id,
                UserName = cartModel.UserName,
                Items = cartModel.Items?.Select(i => i.ToCartItemEntity()).ToList() ?? new List<CartItem>(),
                // TotalPrice = cartModel.TotalPrice
            };
        }
    }
}