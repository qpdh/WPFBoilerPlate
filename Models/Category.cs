using System.Collections.ObjectModel;
using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Models
{
    public class Category : IBaseModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; private set; } = new ObservableCollection<Product>();
    }
}
