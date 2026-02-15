using Microsoft.EntityFrameworkCore;
using WPFBoilerPlate.Models.Entities;
using WPFBoilerPlate.Repositories.Interfaces;
using WPFBoilerPlate.Utils;

namespace WPFBoilerPlate.Repositories
{
    public class ProductRepository : IBaseRepository<ProductEntity>
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<ProductEntity> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return product;
        }

        public async Task<List<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync<ProductEntity>();
        }

        public async Task<ProductEntity?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductEntity> UpdateAsync(ProductEntity entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}