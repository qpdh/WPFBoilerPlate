using WPFBoilerPlate.Models.Interfaces;

namespace WPFBoilerPlate.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IBaseModel
    {
        Task<List<T>> GetAllAsync();

        Task<T?> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(int id);
    }
}