using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFBoilerPlate.Models.Dtos.Categories;
using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.Services.Categories;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.Services.Products;
using WPFBoilerPlate.ViewModels.Interfaces;

namespace WPFBoilerPlate.ViewModels
{
    public partial class ProductDetailViewModel : ObservableValidator, IBaseViewModel
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IWindowService windowService;

        [ObservableProperty]
        private ProductViewModel productViewModel;

        [ObservableProperty]
        private List<CategoryDto> categories;

        public ProductDetailViewModel(IProductService productService, ICategoryService categoryService, IWindowService windowService, int productId)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.windowService = windowService;

            OnLoaded(productId);
        }

        private async void OnLoaded(int id)
        {
            var categoriesResult = await categoryService.GetCategoriesAsync();
            if (!categoriesResult.IsSuccess)
            {
                throw new InvalidOperationException(categoriesResult.Error);
            }
            Categories = categoriesResult.Value;

            var productResult = await productService.GetProductAsync(id);
            if (!productResult.IsSuccess)
            {
                throw new InvalidOperationException(productResult.Error);
            }
            ProductViewModel = new ProductViewModel(productResult.Value);
        }

        [RelayCommand]
        public async Task UpdateProduct()
        {
            if (!ProductViewModel.IsValid())
            {
                MessageBox.Show("제품 수정 실패", "제품 수정 실패", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ProductUpdateDto dto = new ProductUpdateDto()
            {
                ProductId = ProductViewModel.Product.ProductId,
                Name = ProductViewModel.Name,
                CategoryId = ProductViewModel.CategoryId,
            };

            await productService.UpdateProductAsync(dto);
        }

        [RelayCommand]
        public async Task DeleteProduct()
        {
            if (MessageBox.Show("정말로 지우시겠습니까?", "삭제 확인", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                await productService.DeleteProductAsync(ProductViewModel.Product.ProductId);
                windowService.CloseWindow(this);
            }
        }
    }
}