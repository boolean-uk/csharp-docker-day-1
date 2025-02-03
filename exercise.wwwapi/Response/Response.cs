namespace api_cinema_challenge.Response
{
    public class Response<T>
    {
        public string status { get; set; }
        public T data { get; set; }

        public Response(string status, T data)
        {
            this.status = status;
            this.data = data;
        }
    }
    
}
