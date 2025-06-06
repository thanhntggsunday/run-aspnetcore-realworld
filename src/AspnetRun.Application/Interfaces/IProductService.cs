using AspnetRun.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProductList();
        Task<ProductModel> GetProductById(int productId);
        Task<ProductModel> GetProductBySlug(string slug);
        Task<List<ProductModel>> GetProductByName(string productName);
        Task<List<ProductModel>> GetProductByCategory(int categoryId);
        Task<ProductModel> Create(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(ProductModel productModel);
    }
}
