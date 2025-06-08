using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using NetMvc.Cms.Common.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IProductService _productAppService;
        // private readonly IMapper _mapper;

        public IndexPageService(IProductService productAppService, IMapper mapper)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            // _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ListViewModel<ProductDto>> GetProducts()
        {
            var list = await _productAppService.GetProductList();
            // var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            var mapped = new ListViewModel<ProductDto>();
            mapped.Data = list;

            return mapped;
        }
    }
}
