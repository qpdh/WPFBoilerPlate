namespace WPFBoilerPlate.Models.Dtos.Categories
{
    public sealed class CategoryUpdateDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}