namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get(int id, string? include=null);
        Task<IEnumerable<T>> GetAll(string? include=null);
        Task<T> Delete(int id);
        Task<T> Update(T entity, int id);
        Task<T> Add(T entity);
    }

}
