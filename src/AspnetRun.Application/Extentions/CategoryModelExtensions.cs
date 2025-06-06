using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Extentions
{
    public static class CategoryModelExtensions
    {
        public static CategoryModel ToCategoryModel(this Category category)
        {
            if (category == null) return null;

            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageName = category.ImageName
            };
        }
    }
}
