using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
    }

}
