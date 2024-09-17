using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetObjects();
        Task<T> GetObject(IFilter<T> filter, int id);
        Task<T> CreateObject(IFilter<T> filter, T entity);
        Task<T> UpdateObject(int id, string stringOne, string stringTwo, DateTime date);
        Task<T> DeleteObject(int id);
    }
}
