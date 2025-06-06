using AspnetRun.Application.Models.Base;

namespace AspnetRun.Application.Models
{
    public class CategoryDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
    }
}
