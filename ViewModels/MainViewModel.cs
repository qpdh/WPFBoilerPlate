using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WPFBoilerPlate.Messages;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Services.Interfaces;
using WPFBoilerPlate.ViewModels.Interfaces;
using WPFBoilerPlate.Views;

namespace WPFBoilerPlate.ViewModels
{
    public partial class MainViewModel : ObservableObject, IBaseViewModel, IRecipient<ProductUpdatedMessage>, IRecipient<ProductDeletedMessage>, IRecipient<ProductCreatedMessage>
    {
        private readonly IWindowService windowService;
        private readonly IProductService productService;

        [ObservableProperty]
        private ObservableCollection<Product> products;

        [ObservableProperty]
        private Product selectedProduct;

        [ObservableProperty]
        private bool isLoading;

        public MainViewModel(IWindowService windowService, IProductService productService)
        {
            this.windowService = windowService;
            this.productService = productService;

            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        [RelayCommand]
        private async Task LoadAsync()
        {
            IsLoading = true;
            try
            {
                Products = new ObservableCollection<Product>(await productService.GetProductsAsync());
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private void ItemDoubleClick(Product? product)
        {
            if (product == null)
            {
                return;
            }

            windowService.ShowDialog<ProductDetailWindow, ProductViewModel>(product);
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
            if (updated == null)
            {
                return;
            }

            var index = Products
                .Select((p, i) => new { p, i })
                .FirstOrDefault(x => x.p.ProductId == updated.ProductId)?.i;
            if (index is null)
            {
                return;
            }

            Products.RemoveAt(index.Value);
            Products.Insert(index.Value, updated);
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
            var newProduct = await productService.GetProductAsync(message.ProductId);
            if (newProduct == null)
            {
                return;
            }

            Products.Add(newProduct);
        }
    }
}
