using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;

namespace AspnetRun.Shared.Extentions
{
    public static class WishlistModelExtensions
    {
        public static WishlistDto ToWishlistDto(this Wishlist wishlist)
        {
            if (wishlist == null) return null;
            return new WishlistDto()
            {
                Id = wishlist.Id,
                UserName = wishlist.UserName
                // ,Items = wishlist.Items?.ToWishlistItemDtoList() ?? new List<WishlistItemDto>()
            };
        }

        public static List<WishlistDto> ToWishlistDtoList(this List<Wishlist> wishlists)
        {
            if (wishlists == null) return null;
            var result = new List<WishlistDto>();
            for (var i = 0; i < wishlists.Count; i++)
            {
                result.Add(wishlists[i].ToWishlistDto());
            }
            return result;
        }
    }
}