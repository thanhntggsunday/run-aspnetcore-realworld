using AspnetRun.Application.Models;
using AspnetRun.Shared.ViewModels.Common;
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
    public class ProductsModel : PageModel
    {
        private readonly IProductPageService _productPageService;        
        private readonly ICartComponentService _cartComponentService; // due to every page has cart, we also inject cart view component service in order to catch post actions

        public ProductsModel(IProductPageService productPageService, ICartComponentService cartComponentService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public PagedResults<ProductDto> ProductList { get; set; } = new PagedResults<ProductDto>(0);

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        public async Task OnGetAsync(int pageNumber = 1)
        {
            string searchTerm = SearchTerm;
            ProductList = await _productPageService.GetProductsPaging(pageNumber, searchTerm);
        }
        
        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            if(!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToCart(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToWishlist(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCompareAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToCompare(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }

    }
}