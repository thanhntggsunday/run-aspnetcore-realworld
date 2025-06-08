using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Shared.Extentions
{
    public static class CartItemModelExtensions
    {
        public static CartItemDto ToCartItemDto(this CartItem cartItem)
        {
            if (cartItem == null) return null;

            return new CartItemDto()
            {
                Id = cartItem.Id,
                UnitPrice = cartItem.UnitPrice,
                Color = cartItem.Color,
                Product = cartItem.Product?.ToProductDto(),
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.TotalPrice
            };
        }


        public static List<CartItemDto> ToCartItemDtoList(this List<CartItem> cartItems)
        {
            if (cartItems == null) return null;

            var resutl = new List<CartItemDto>();

            for ( var i = 0; i < cartItems.Count; i++ )
            {
                resutl.Add(cartItems[i].ToCartItemDto());
            }
            
            return resutl;
        }

        public static CartItem ToCartItemEntity(this CartItemDto cartItem)
        {
            if (cartItem == null) return null;

            return new CartItem()
            {
                Id = cartItem.Id,
                UnitPrice = cartItem.UnitPrice,
                Color = cartItem.Color,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.TotalPrice
            };
        }
    }
}