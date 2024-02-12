using exercise.wwwapi.Models.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> SelectAll();
        Task<T?> SelectById(int id);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
    }
}
