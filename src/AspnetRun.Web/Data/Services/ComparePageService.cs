﻿using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Data.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;

namespace AspnetRun.Web.Data.Services
{
    public class ComparePageService : IComparePageService
    {
        private readonly ICompareService _compareAppService;
        private readonly ICartService _cartAppService;
        // private readonly IMapper _mapper;
        private readonly ILogger<ComparePageService> _logger;

        public ComparePageService(ICompareService compareAppService, ICartService cartAppService, IMapper mapper, ILogger<ComparePageService> logger)
        {
            _compareAppService = compareAppService ?? throw new ArgumentNullException(nameof(compareAppService));
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
           // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CompareViewModel> GetCompare(string userName)
        {
            var compare = await _compareAppService.GetCompareByUserName(userName);
            // var mapped = _mapper.Map<CompareViewModel>(compare);
            var mapped = new CompareViewModel()
            {
               Data = compare
            };

            return mapped;
        }

        public async Task RemoveItem(int compareId, int productId)
        {
            await _compareAppService.RemoveItem(compareId, productId);
        }

        public async Task AddToCart(string userName, int productId)
        {
            await _cartAppService.AddItem(userName, productId);
        }
    }
}