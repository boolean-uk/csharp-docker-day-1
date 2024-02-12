using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Delete(int id);
        Task<T> Update(T entity, int id);
        Task<T> Add(T entity);
    }

}
