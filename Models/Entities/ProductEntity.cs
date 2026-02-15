using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Models.Entities
{
    public class ProductEntity : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}