using WPFBoilerPlate.Models;

namespace WPFBoilerPlate.Services.Interfaces
{
    public interface IProductService : IDataBaseService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
