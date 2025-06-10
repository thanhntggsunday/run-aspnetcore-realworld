using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;
using AspnetRun.Shared.Extentions;
using Microsoft.Extensions.Logging;

namespace AspnetRun.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<CategoryDto>> GetCategoryList()
        {
            var category = await _categoryRepository.GetAllAsync();
            var mapped = category.ToList().ToCatergoryItemDtoList();
            return mapped;
        }        
        
    }
}
