using WPFBoilerPlate.Models;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Services.Interfaces;

namespace WPFBoilerPlate.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _repository;

        public CategoryService(IBaseRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            bool isExists = (await _repository.GetByIdAsync(category.CategoryId)) != null;
            if (isExists)
            {
                return false;
            }

            await _repository.AddAsync(category);

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            bool isExists = (await _repository.GetByIdAsync(id)) != null;
            if (!isExists)
            {
                return false;
            }

            await _repository.DeleteAsync(id);

            return true;
        }

        public Task<Category?> GetCategoryAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            bool isExists = (await _repository.GetByIdAsync(category.CategoryId)) != null;
            if (!isExists)
            {
                return false;
            }

            await _repository.UpdateAsync(category);

            return true;
        }
    }
}
