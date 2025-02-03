using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(object id);
        DbSet<T> Table { get; }
    }

}
