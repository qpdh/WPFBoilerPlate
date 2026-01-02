using CommunityToolkit.Mvvm.Messaging;
using WPFBoilerPlate.Messages;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Services.Interfaces;

namespace WPFBoilerPlate.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _repository;

        public ProductService(IBaseRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            bool isExists = (await _repository.GetByIdAsync(product.ProductId)) != null;
            if (isExists)
            {
                return false;
            }

            await _repository.AddAsync(product);

            WeakReferenceMessenger.Default.Send(new ProductCreatedMessage(product.ProductId));

            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            bool isExists = (await _repository.GetByIdAsync(id)) != null;
            if (!isExists)
            {
                return false;
            }

            await _repository.DeleteAsync(id);

            WeakReferenceMessenger.Default.Send(new ProductDeletedMessage(id));

            return true;
        }

        public Task<Product?> GetProductAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            bool isExists = (await _repository.GetByIdAsync(product.ProductId)) != null;
            if (isExists is false)
            {
                return false;
            }

            await _repository.UpdateAsync(product);

            WeakReferenceMessenger.Default.Send(new ProductUpdatedMessage(product.ProductId));

            return true;
        }
    }
}
