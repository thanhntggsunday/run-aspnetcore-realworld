using AspnetRun.Application.Models;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetMvc.Cms.Common.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IIndexPageService _indexPageService;
        private readonly ICartComponentService _cartComponentService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IIndexPageService indexPageService, ICartComponentService cartComponentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public ListViewModel<ProductDto> ProductList { get; set; } = new ListViewModel<ProductDto>();
        public CategoryViewModel CategoryModel { get; set; } = new CategoryViewModel();

        public async Task OnGetAsync()
        {
            ProductList = await _indexPageService.GetProducts();

            _logger.LogInformation("Index page loaded with {ProductCount} products.", ProductList.Data.Count);
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }
    }
}
