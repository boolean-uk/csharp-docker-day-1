using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
    }

}
