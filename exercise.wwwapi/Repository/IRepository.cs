using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetObjects();
        T GetObject(IFilter<T> filter, int id);
        Task<T> CreateObject(IFilter<T> filter, T entity);
        Task<T> UpdateObject(IFilter<T> filter, int id, string stringOne, string stringTwo, DateTime date);
        Task<T> DeleteObject(IFilter<T> filter, int id);
    }
}
