using AspnetRun.Application.Models;
using NetMvc.Cms.Common.ViewModel.Common;

namespace AspnetRun.Web.Data.Interfaces
{
    public interface ICategoryPageService
    {
        Task<ListViewModel<CategoryDto>> GetCategories();
    }
}