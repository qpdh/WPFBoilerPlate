using Microsoft.EntityFrameworkCore;

using WPFBoilerPlate.Models.Entities;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Utils;

namespace WPFBoilerPlate.Repositories
{
    public class CategoryRepository : IBaseRepository<CategoryEntity>
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<CategoryEntity> AddAsync(CategoryEntity entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<CategoryEntity> DeleteAsync(int id)
        {
            CategoryEntity category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

            return category;
        }

        public async Task<List<CategoryEntity>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync<CategoryEntity>();
        }

        public async Task<CategoryEntity?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<CategoryEntity> UpdateAsync(CategoryEntity entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}