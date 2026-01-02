using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using WPFBoilerPlate.Messages;
using WPFBoilerPlate.Models;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Utils;

namespace WPFBoilerPlate.Repositories
{
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly AppDBContext _context;

        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
            WeakReferenceMessenger.Default.Send(new LoadCategoryMessage());
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                WeakReferenceMessenger.Default.Send(new LoadCategoryMessage());
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync<Category>();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            WeakReferenceMessenger.Default.Send(new LoadCategoryMessage());
        }
    }
}
