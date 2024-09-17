using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public interface IFilter<T>
    {
        IEnumerable<T> FilterById(IEnumerable<T> db, int id);

        T AssignIdToEntity(IEnumerable<T> table, T entity);

        T AssignNewData(DataContext db, int id, string stringOne, string stringTwo, DateTime date);
        
    }
}
