using AspnetRun.Web.ViewModels;
using System.Threading.Tasks;

namespace AspnetRun.Web.Data.Interfaces
{
    public interface ICheckOutPageService
    {
        Task<CartViewModel> GetCart(string userName);        
        Task CheckOut(OrderViewModel order, string userName);
    }
}
