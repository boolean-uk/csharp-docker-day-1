namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public required T Data { get; set; }
    }
}
