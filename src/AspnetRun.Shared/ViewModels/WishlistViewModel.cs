using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class WishlistViewModel : TransactionalInformation
    {
        public WishlistDto Data { get; set; } = new WishlistDto();
       
    }
}
