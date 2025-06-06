using AspnetRun.Application.Models.Base;
using System.Collections.Generic;

namespace AspnetRun.Application.Models
{
    public class CartDto : BaseDto
    {
        public string? UserName { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
