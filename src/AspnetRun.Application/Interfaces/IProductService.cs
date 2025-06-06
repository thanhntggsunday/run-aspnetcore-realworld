using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductList();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> GetProductBySlug(string slug);
        Task<List<ProductDto>> GetProductByName(string productName);
        Task<List<ProductDto>> GetProductByCategory(int categoryId);
        Task<ProductDto> Create(ProductDto productModel);
        Task Update(ProductDto productModel);
        Task Delete(ProductDto productModel);
    }
}
