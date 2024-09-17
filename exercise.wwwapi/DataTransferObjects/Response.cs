namespace exercise.wwwapi.DataTransferObjects
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
    }
}
