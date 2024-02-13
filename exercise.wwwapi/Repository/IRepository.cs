using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Update(T entity);

        Task<T> Delete(int id);

    }

}
