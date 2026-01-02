using WPFBoilerPlate.Models;

namespace WPFBoilerPlate.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int id);
        Task<bool> AddCategoryAsync(Category product);
        Task<bool> UpdateCategoryAsync(Category product);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
