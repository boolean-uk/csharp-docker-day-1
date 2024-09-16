namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public bool status {  get; set; }
        public T Data { get; set; }
    }
}
