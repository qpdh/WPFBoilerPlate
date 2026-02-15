using WPFBoilerPlate.Models.Dtos.Categories;

namespace WPFBoilerPlate.Models.Dtos.Products
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}