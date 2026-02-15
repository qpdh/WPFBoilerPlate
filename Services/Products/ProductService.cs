using CommunityToolkit.Mvvm.Messaging;
using WPFBoilerPlate.Models.Dtos;
using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.Models.Entities;
using WPFBoilerPlate.Models.Mappers;
using WPFBoilerPlate.Models.Messages;
using WPFBoilerPlate.Repositories.Interfaces;

namespace WPFBoilerPlate.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<ProductEntity> _repository;

        public ProductService(IBaseRepository<ProductEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result<ProductDto>> AddProductAsync(ProductCreateDto product)
        {
            var entity = ProductMapper.ToEntity(product);
            await _repository.AddAsync(entity);

            WeakReferenceMessenger.Default.Send(new ProductCreatedMessage(ProductMapper.ToDto(entity)));

            return Result<ProductDto>.Success(ProductMapper.ToDto(entity));
        }

        public async Task<Result<ProductDto>> DeleteProductAsync(int id)
        {
            ProductEntity entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Result<ProductDto>.Failure("Product not found");
            }

            await _repository.DeleteAsync(id);

            WeakReferenceMessenger.Default.Send(new ProductDeletedMessage(id));

            return Result<ProductDto>.Success(ProductMapper.ToDto(entity));
        }

        public async Task<Result<ProductDto>> GetProductAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Result<ProductDto>.Failure("Product not found");
            }

            return Result<ProductDto>.Success(ProductMapper.ToDto(entity));
        }

        public async Task<Result<List<ProductDto>>> GetProductsAsync()
        {
            var entities = await _repository.GetAllAsync();

            return Result<List<ProductDto>>.Success(entities.Select(ProductMapper.ToDto).ToList()!);
        }

        public async Task<Result<ProductDto>> UpdateProductAsync(ProductUpdateDto product)
        {
            ProductEntity entity = await _repository.GetByIdAsync(product.ProductId);
            if (entity == null)
            {
                return Result<ProductDto>.Failure("Product not found");
            }

            entity.Name = product.Name;
            entity.CategoryId = product.CategoryId;
            entity.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(entity);

            WeakReferenceMessenger.Default.Send(new ProductUpdatedMessage(product.ProductId));

            return Result<ProductDto>.Success(ProductMapper.ToDto(entity));
        }
    }
}