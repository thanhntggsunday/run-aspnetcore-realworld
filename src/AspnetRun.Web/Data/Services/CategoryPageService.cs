using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using NetMvc.Cms.Common.ViewModel.Common;

namespace AspnetRun.Web.Data.Services
{
    public class CategoryPageService : ICategoryPageService
    {
        private readonly ICategoryService _categoryAppService;
        // private readonly IMapper _mapper;

        public CategoryPageService(ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListViewModel<CategoryDto>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = new ListViewModel<CategoryDto>();

            mapped.Data = list;

            return mapped;
        }
    }
}