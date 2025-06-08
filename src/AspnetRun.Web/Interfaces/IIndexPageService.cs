using AspnetRun.Application.Models;
using NetMvc.Cms.Common.ViewModel.Common;

namespace AspnetRun.Web.Interfaces
{
    // NOTE : This is the whole page service, it could be include all categories and products
    // this is the razor page based service
    public interface IIndexPageService
    {
        Task<ListViewModel<ProductDto>> GetProducts();
    }
}