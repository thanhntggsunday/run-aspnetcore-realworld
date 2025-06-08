using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Application.Extentions
{
    public static class CategoryModelExtensions
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageName = category.ImageName
            };
        }

        public static Category ToCategoryEntity(this CategoryDto category)
        {
            if (category == null) return null;

            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageName = category.ImageName
            };
        }
    }
}