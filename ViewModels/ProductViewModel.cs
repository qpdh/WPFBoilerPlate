using System.ComponentModel.DataAnnotations;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductViewModel : ObservableValidator, IBaseViewModel
    {
        private readonly IProductService productService;
        private readonly IWindowService windowService;

        [ObservableProperty]
        private Product product;

        [Required]
        [Length(3, 30)]
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private Category category;

        public List<Category> Categories { get; }

        public ProductViewModel(IProductService productService, ICategoryService categoryService, IWindowService windowService, Product product)
        {
            this.productService = productService;
            this.windowService = windowService;
            Product = product;
            Categories = categoryService.GetCategoriesAsync().Result;
        }

        partial void OnProductChanged(Product? oldValue, Product newValue)
        {
            // Data Load
            Name = newValue.Name;
            Category = newValue.Category;
        }

        [RelayCommand]
        public async Task UpdateProduct()
        {
            ValidateAllProperties();
            if (HasErrors)
            {
                MessageBox.Show("제품 수정 실패", "제품 수정 실패", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Product.Name = Name;
            Product.CategoryId = Category.CategoryId;

            await productService.UpdateProductAsync(Product);
        }

        [RelayCommand]
        public async Task DeleteProduct()
        {
            if (MessageBox.Show("정말로 지우시겠습니까?", "삭제 확인", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                await productService.DeleteProductAsync(Product.ProductId);
                windowService.CloseWindow(this);
            }
        }
    }
}
