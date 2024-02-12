namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
