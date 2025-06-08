using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class OrderItemView : TransactionalInformation
    {
        public int Quantity { get; set; }
        public string? Color { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = new ProductDto();
    }
}
