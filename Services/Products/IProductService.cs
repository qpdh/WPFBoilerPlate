using WPFBoilerPlate.Models.Dtos;
using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.Services.Interfaces;

namespace WPFBoilerPlate.Services.Products
{
    public interface IProductService : IDataBaseService
    {
        Task<Result<List<ProductDto>>> GetProductsAsync();

        Task<Result<ProductDto>> GetProductAsync(int id);

        Task<Result<ProductDto>> AddProductAsync(ProductCreateDto product);

        Task<Result<ProductDto>> UpdateProductAsync(ProductUpdateDto product);

        Task<Result<ProductDto>> DeleteProductAsync(int id);
    }
}