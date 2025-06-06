using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class OrderItemDto : BaseDto
    {
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
}
