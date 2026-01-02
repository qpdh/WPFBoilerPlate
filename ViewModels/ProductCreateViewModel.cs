using System.ComponentModel.DataAnnotations;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductCreateViewModel : ObservableValidator, IBaseViewModel
    {
        private readonly IProductService productService;
        private readonly IWindowService windowService;

        [ObservableProperty]
        [Length(minimumLength: 3, maximumLength: 30)]
        [Required]
        private string name;

        partial void OnNameChanged(string value)
        {
            ValidateProperty(value, nameof(Name));
        }

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
            ValidateAllProperties();
            if (HasErrors)
            {
                MessageBox.Show("제품 생성 실패", "제품 생성 실패", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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
