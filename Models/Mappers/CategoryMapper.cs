using WPFBoilerPlate.Models.Dtos.Categories;
using WPFBoilerPlate.Models.Entities;

namespace WPFBoilerPlate.Models.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto? ToDto(CategoryEntity? entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CategoryDto()
            {
                CategoryId = entity.Id,
                Name = entity.Name,
            };
        }

        internal static CategoryEntity ToEntity(CategoryCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}