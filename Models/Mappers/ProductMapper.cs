using WPFBoilerPlate.Models.Dtos.Products;
using WPFBoilerPlate.Models.Entities;

namespace WPFBoilerPlate.Models.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto? ToDto(ProductEntity? entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProductDto()
            {
                ProductId = entity.Id,
                Name = entity.Name,
                Category = CategoryMapper.ToDto(entity.Category),
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };
        }

        public static ProductEntity? ToEntity(ProductCreateDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ProductEntity()
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
            };
        }

        public static ProductEntity? ToEntity(ProductUpdateDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ProductEntity()
            {
                Id = dto.ProductId,
                Name = dto.Name,
                CategoryId = dto.CategoryId,
            };
        }
    }
}