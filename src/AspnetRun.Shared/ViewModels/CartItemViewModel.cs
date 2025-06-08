using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class CartItemViewModel : TransactionalInformation
    {
       public CartItemDto Data { get; set; }
        public CartItemViewModel()
        {
            Data = new CartItemDto();
        }
        public CartItemViewModel(CartItemDto data)
        {
            Data = data;
        }
    }
}
