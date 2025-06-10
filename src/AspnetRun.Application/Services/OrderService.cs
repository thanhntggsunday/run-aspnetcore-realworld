using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Core.Repositories;
using AspnetRun.Shared.Extentions;
using Microsoft.Extensions.Logging;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderDto> CheckOut(OrderDto orderModel)
        {            
            ValidateOrder(orderModel);

            var mappedEntity = orderModel.ToOrderEntity();
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _orderRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = newEntity.ToOrderDto();
            return newMappedEntity;
        }

        private void ValidateOrder(OrderDto orderModel)
        {
            // TODO : apply validations - i.e. - customer has only 3 order or order item should be low than 5 etc..
            if (string.IsNullOrWhiteSpace(orderModel.UserName))
            {
                throw new ApplicationException($"Order username must be defined");
            }

            if (orderModel.Items.Count == 0)
            {
                throw new ApplicationException($"Order should have at least one item");
            }

            if (orderModel.Items.Count > 10)
            {
                throw new ApplicationException($"Order has maximum 10 items");
            }
        }
    }
}
