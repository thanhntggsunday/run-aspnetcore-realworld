using AspnetRun.Application.Models;
using AspnetRun.Web.ViewModels;
using NetMvc.Cms.Common.ViewModel.Common;

namespace AspnetRun.Web.Data.Interfaces
{
    public interface IProductPageService
    {
        Task<ListViewModel<ProductDto>> GetProducts(string productName);

        Task<ProductViewModel> GetProductById(int productId);

        Task<ProductViewModel> GetProductBySlug(string slug);

        Task<ListViewModel<ProductDto>> GetProductByCategory(int categoryId);

        Task<ListViewModel<CategoryDto>> GetCategories();

        Task AddToCart(string userName, int productId);

        Task AddToWishlist(string userName, int productId);

        Task AddToCompare(string userName, int productId);
    }
}