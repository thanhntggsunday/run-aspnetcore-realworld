using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Extentions
{
    public static class ProductModelExtensions
    {
        public static ProductModel ToProductModel(this Product product)
        {
            if (product == null) return null;

            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                ImageFile = product.ImageFile,
                CategoryId = product.CategoryId,
                Slug = product.Slug,
                Star= product.Star,
                Summary = product.Summary,
                UnitsInStock = product.UnitsInStock,
                Category = product.Category != null ? new CategoryModel
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name,
                    Description = product.Category.Description,
                    ImageName = product.Category.ImageName
                } : null
            };
        }

        public static List<ProductModel> ToProductModelList(this List<Product> products)
        {
           var result = new List<ProductModel>();

            if (products == null || !products.Any()) return result;

            foreach (var product in products)
            {
                result.Add(product.ToProductModel());
            }

            return result;
        }

        public static Product ToProductEntity(this ProductModel productModel)
        {
            if (productModel == null) return null;

            return new Product
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                UnitPrice = productModel.UnitPrice ?? 0,
                ImageFile = productModel.ImageFile,
                CategoryId = productModel.CategoryId ?? 0,
                Slug = productModel.Slug,
                Star = productModel.Star,
                Summary = productModel.Summary,
                UnitsInStock = productModel.UnitsInStock ?? 0
            };
        }
    }
}
