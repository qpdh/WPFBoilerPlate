using WPFBoilerPlate.Models.Dtos;
using WPFBoilerPlate.Models.Dtos.Categories;
using WPFBoilerPlate.Models.Entities;
using WPFBoilerPlate.Models.Mappers;
using WPFBoilerPlate.Repositories.Interfaces;

namespace WPFBoilerPlate.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<CategoryEntity> _repository;

        public CategoryService(IBaseRepository<CategoryEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result<CategoryDto>> AddCategoryAsync(CategoryCreateDto dto)
        {
            var entity = CategoryMapper.ToEntity(dto);
            await _repository.AddAsync(entity);

            return Result<CategoryDto>.Success(CategoryMapper.ToDto(entity));
        }

        public async Task<Result<CategoryDto>> DeleteCategoryAsync(int id)
        {
            bool isExists = (await _repository.GetByIdAsync(id)) != null;
            if (!isExists)
            {
                return Result<CategoryDto>.Failure("Category not found");
            }

            CategoryEntity entity = await _repository.DeleteAsync(id);
            return Result<CategoryDto>.Success(CategoryMapper.ToDto(entity));
        }

        public async Task<Result<CategoryDto>> GetCategoryAsync(int id)
        {
            CategoryEntity? entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return Result<CategoryDto>.Failure($"Could not find {id} category");
            }

            return Result<CategoryDto>.Success(CategoryMapper.ToDto(entity)!);
        }

        public async Task<Result<List<CategoryDto>>> GetCategoriesAsync()
        {
            List<CategoryEntity> entities = await _repository.GetAllAsync();
            return Result<List<CategoryDto>>.Success(entities.Select(CategoryMapper.ToDto).ToList()!);
        }

        public async Task<Result<CategoryDto>> UpdateCategoryAsync(CategoryUpdateDto category)
        {
            var entity = await _repository.GetByIdAsync(category.CategoryId);
            if (entity == null)
            {
                return Result<CategoryDto>.Failure($"{category} not found");
            }

            await _repository.UpdateAsync(entity);

            return Result<CategoryDto>.Success(CategoryMapper.ToDto(entity));
        }
    }
}