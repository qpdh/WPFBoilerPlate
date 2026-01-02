using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductCreateViewModel : ObservableObject, IBaseViewModel
    {
        private readonly IProductService productService;
        private readonly IWindowService windowService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private Category category;

        public List<Category> Categories { get; }


        public ProductCreateViewModel(IProductService productService, ICategoryService categoryService, IWindowService windowService)
        {
            this.productService = productService;
            this.windowService = windowService;
            Categories = categoryService.GetCategoriesAsync().Result;
            Category = Categories[0];
        }

        [RelayCommand]
        public async Task CreateProduct()
        {
            if (MessageBox.Show("정말로 생성하시겠습니까?", "생성 확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Product product = new()
                {
                    Name = Name,
                    CategoryId = Category.CategoryId,
                };

                await productService.AddProductAsync(product);
                windowService.CloseWindow(this);
            }
        }
    }
}
