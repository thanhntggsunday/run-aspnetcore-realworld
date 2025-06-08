using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class WishlistViewModel : TransactionalInformation
    {
        public string? UserName { get; set; }
        public List<ProductDto> Items { get; set; } = new List<ProductDto>();
    }
}
