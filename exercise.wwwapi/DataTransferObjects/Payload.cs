using System.Net;

namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public string Status { get; set; }
        public T Data { get; set; }
    }
}
