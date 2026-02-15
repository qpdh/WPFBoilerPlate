using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.Models.Messages;
using WPFBoilerPlate.Services.Categories;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.Services.Products;
using WPFBoilerPlate.ViewModels.Interfaces;
using WPFBoilerPlate.Views;

namespace WPFBoilerPlate.ViewModels
{
    public partial class MainViewModel : ObservableObject, IBaseViewModel, IRecipient<ProductUpdatedMessage>, IRecipient<ProductDeletedMessage>, IRecipient<ProductCreatedMessage>
    {
        private readonly IWindowService windowService;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        [ObservableProperty]
        private ObservableCollection<ProductDto> products;

        [ObservableProperty]
        private ProductDto selectedProduct;

        [ObservableProperty]
        private bool isLoading;

        public MainViewModel(IWindowService windowService, IProductService productService, ICategoryService categoryService)
        {
            this.windowService = windowService;
            this.productService = productService;
            this.categoryService = categoryService;
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        [RelayCommand]
        private async Task LoadAsync()
        {
            IsLoading = true;
            try
            {
                var productResult = await productService.GetProductsAsync();
                Products = new ObservableCollection<ProductDto>(productResult.Value);
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private void ItemDoubleClick(ProductDto? product)
        {
            if (product == null)
            {
                return;
            }

            windowService.ShowDialog<ProductDetailWindow, ProductDetailViewModel>(product.ProductId);
        }

        [RelayCommand]
        private void CreateProduct()
        {
            windowService.ShowDialog<ProductCreateWindow, ProductCreateViewModel>();
        }

        [RelayCommand]
        private void ChangeLanguage()
        {
            windowService.ShowDialog<LanguageChangeWindow, LanguageChangeViewModel>();
        }

        public void Receive(ProductUpdatedMessage message)
        {
            _ = Application.Current.Dispatcher.InvokeAsync(() => OnProductUpdatedAsync(message));
        }

        private async Task OnProductUpdatedAsync(ProductUpdatedMessage message)
        {
            var updated = await productService.GetProductAsync(message.ProductId);
            if (updated.IsSuccess == false)
            {
                return;
            }

            var index = Products
                .Select((p, i) => new { p, i })
                .FirstOrDefault(x => x.p.ProductId == updated.Value.ProductId)?.i;
            if (index is null)
            {
                return;
            }

            Products.RemoveAt(index.Value);
            Products.Insert(index.Value, updated.Value);
        }

        public void Receive(ProductDeletedMessage message)
        {
            _ = Application.Current.Dispatcher.InvokeAsync(() => OnProductDeletedAsync(message));
        }

        private async Task OnProductDeletedAsync(ProductDeletedMessage message)
        {
            var index = Products
                .Select((p, i) => new { p, i })
                .FirstOrDefault(x => x.p.ProductId == message.ProductId)?.i;
            if (index is null)
            {
                return;
            }

            Products.RemoveAt(index.Value);
        }

        public void Receive(ProductCreatedMessage message)
        {
            _ = Application.Current.Dispatcher.InvokeAsync(() => OnProductCreatedAsync(message));
        }

        private async Task OnProductCreatedAsync(ProductCreatedMessage message)
        {
            var newProduct = await productService.GetProductAsync(message.ProductDto.ProductId);
            if (newProduct.IsSuccess == false)
            {
                return;
            }

            Products.Add(newProduct.Value);
        }
    }
}