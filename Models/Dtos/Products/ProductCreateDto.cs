namespace WPFBoilerPlate.Models.Dtos.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = "";
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}