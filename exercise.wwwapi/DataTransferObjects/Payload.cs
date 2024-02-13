namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public string Status { get; set; } = "success";
        public T data { get; set; }

        public Payload() { }
        public Payload(T data)
        {
            this.data = data;
        }
    }
}
