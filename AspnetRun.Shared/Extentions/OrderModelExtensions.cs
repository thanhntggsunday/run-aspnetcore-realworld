using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Shared.Extentions
{
    public static class OrderModelExtensions
    {
        public static OrderDto ToOrderDto(this Order model)
        {
            if (model == null) return null;

            return new OrderDto
            {
                Id = model.Id,
                UserName = model.UserName ?? string.Empty, // Fix for CS8601: Ensure non-null assignment
                GrandTotal = model.GrandTotal,
                Items = model.Items?.ToOrderItemDtoList() ?? new List<OrderItemDto>() // Fix for CS8601
            };
        }

        public static List<OrderDto> ToOrderDtoList(this List<Order> orders)
        {
            if (orders == null) return null;

            var result = new List<OrderDto>();
            for (var i = 0; i < orders.Count; i++)
            {
                result.Add(orders[i].ToOrderDto());
            }

            return result;
        }

        public static Order ToOrderEntity(this OrderDto model)
        {
            if (model == null) return null;
            return new Order
            {
                Id = model.Id,
                UserName = model.UserName ?? string.Empty, // Fix for CS8601: Ensure non-null assignment
                GrandTotal = model.GrandTotal,
                Items = model.Items?.ToOrderItemEntityList() ?? new List<OrderItem>() // Fix for CS8601
            };
        }
    }
}