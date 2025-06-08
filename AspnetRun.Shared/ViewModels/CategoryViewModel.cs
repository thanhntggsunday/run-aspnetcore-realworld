using AspnetRun.Application.Models;
using AspnetRun.Shared;

namespace AspnetRun.Web.ViewModels
{
    public class CategoryViewModel : TransactionalInformation
    {
        public CategoryDto Data { get; set; } = new CategoryDto();
    }
}
