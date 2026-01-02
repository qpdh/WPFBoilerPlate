using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Models
{
    public class Product : IBaseModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
