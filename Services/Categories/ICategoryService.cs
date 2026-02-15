using WPFBoilerPlate.Models.Dtos;
using WPFBoilerPlate.Models.Dtos.Categories;

namespace WPFBoilerPlate.Services.Categories
{
    public interface ICategoryService
    {
        Task<Result<List<CategoryDto>>> GetCategoriesAsync();

        Task<Result<CategoryDto>> GetCategoryAsync(int id);

        Task<Result<CategoryDto>> AddCategoryAsync(CategoryCreateDto product);

        Task<Result<CategoryDto>> UpdateCategoryAsync(CategoryUpdateDto product);

        Task<Result<CategoryDto>> DeleteCategoryAsync(int id);
    }
}