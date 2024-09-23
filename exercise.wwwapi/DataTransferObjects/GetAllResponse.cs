namespace exercise.wwwapi.DataTransferObjects
{
    public class GetAllResponse<T> where T : class
    {
        List<T> data = new List<T>();
    }
}
