using AspnetRun.Application.Models;
using NetMvc.Cms.Common.ViewModel.Common;

namespace AspnetRun.Web.Interfaces
{
    public interface ICategoryPageService
    {
        Task<ListViewModel<CategoryDto>> GetCategories();
    }
}