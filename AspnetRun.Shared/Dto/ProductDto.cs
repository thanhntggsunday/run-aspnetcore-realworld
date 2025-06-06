using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class ProductDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public double Star { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
