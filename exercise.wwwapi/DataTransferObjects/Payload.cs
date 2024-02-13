namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public string status = "success";
        public T data { get; set; }
    }
}
