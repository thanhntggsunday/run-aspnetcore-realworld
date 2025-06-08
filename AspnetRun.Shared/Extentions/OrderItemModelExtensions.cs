using AspnetRun.Application.Extentions;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Shared.Extentions
{
    public static class OrderItemModelExtensions
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem model)
        {
            if (model == null) return null;

            return new OrderItemDto
            {
                ProductId = model.ProductId,
                Color = model.Color,
                TotalPrice = model.TotalPrice,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Product = model.Product?.ToProductDto()
            };
        }

        public static List<OrderItemDto> ToCartItemDtoList(this List<OrderItem> items)
        {
            if (items == null) return null;

            var resutl = new List<OrderItemDto>();

            for (var i = 0; i < items.Count; i++)
            {
                resutl.Add(items[i].ToOrderItemDto());
            }

            return resutl;
        }

        public static OrderItem ToOrderItemEntity(this OrderItemDto model)
        {
            if (model == null) return null;

            return new OrderItem
            {
                ProductId = model.ProductId,
                Color = model.Color,
                TotalPrice = model.TotalPrice,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice
            };
        }
    }
}