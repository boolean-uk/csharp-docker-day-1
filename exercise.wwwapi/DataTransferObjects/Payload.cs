namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> 
    {
        public Payload(string message, T Data)
        {
            this.message = message;
            this.Data = Data;
        }

        public string message { get; set; }
        public T Data { get; set; }
    }
}
