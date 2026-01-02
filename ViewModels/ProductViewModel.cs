using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductViewModel : ObservableObject, IBaseViewModel
    {
        private readonly IProductService productService;
        private readonly IWindowService windowService;
        [ObservableProperty]
        private Product product;

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
        public async Task CreateProduct()
        {
            if (MessageBox.Show("정말로 생성하시겠습니까?", "생성 확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                await productService.AddProductAsync(Product);
                windowService.CloseWindow(this);
            }
        }

        [RelayCommand]
        public async Task UpdateProduct()
        {
            Product.Name = Name;
            Product.CategoryId = Category.CategoryId;

            await productService.UpdateProductAsync(Product);
        }

        [RelayCommand]
        public async Task DeleteProduct()
        {
            if (MessageBox.Show("정말로 지우시겠습니까?", "삭제 확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                await productService.DeleteProductAsync(Product.ProductId);
                windowService.CloseWindow(this);
            }
        }
    }
}
