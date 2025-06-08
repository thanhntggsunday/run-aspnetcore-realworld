using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class ProductViewModel : TransactionalInformation
    {
        public ProductDto Data { get; set; } = new ProductDto();
    }
}
