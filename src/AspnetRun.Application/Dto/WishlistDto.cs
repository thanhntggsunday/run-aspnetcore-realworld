using AspnetRun.Application.Models.Base;
using System.Collections.Generic;

namespace AspnetRun.Application.Models
{
    public class WishlistDto : BaseDto
    {
        public string? UserName { get; set; }
        public List<ProductDto> Items { get; set; } = new List<ProductDto>();
    }
}
