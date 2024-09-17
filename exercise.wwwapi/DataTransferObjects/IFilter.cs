namespace exercise.wwwapi.DataTransferObjects
{
    public interface IFilter<T>
    {
        IEnumerable<T> FilterById(IEnumerable<T> db, int id);
        
    }
}
