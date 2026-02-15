using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductViewModel : ObservableValidator, IBaseViewModel
    {
        [ObservableProperty]
        private ProductDto product;

        [Required]
        [Length(3, 30)]
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private int categoryId;

        [ObservableProperty]
        private string categoryName;

        public ProductViewModel(ProductDto product)
        {
            Product = product;

            Name = Product.Name;
            CategoryId = Product.Category.CategoryId;
            CategoryName = Product.Category.Name;
        }

        public bool IsValid()
        {
            ValidateAllProperties();
            return !HasErrors;
        }
    }
}