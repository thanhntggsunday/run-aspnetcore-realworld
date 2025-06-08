using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Shared.Extentions;

namespace AspnetRun.Shared.Extentions
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

        public static List<CategoryDto> ToCatergoryItemDtoList(this List<Category> items)
        {
            if (items == null) return null;

            var resutl = new List<CategoryDto>();

            for (var i = 0; i < items.Count; i++)
            {
                resutl.Add(items[i].ToCategoryDto());
            }

            return resutl;
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