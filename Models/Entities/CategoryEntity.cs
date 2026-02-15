using System.Collections.ObjectModel;
using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Models.Entities
{
    public class CategoryEntity : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductEntity> Products { get; private set; } = new ObservableCollection<ProductEntity>();
    }
}