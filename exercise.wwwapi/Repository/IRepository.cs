using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<T> AddNewObject(T newObject);
        Task<T> DeleteObject(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Update(T updateObject);
    }

}
