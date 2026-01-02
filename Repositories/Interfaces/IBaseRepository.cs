using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IBaseModel
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
