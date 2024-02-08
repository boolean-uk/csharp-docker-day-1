namespace exercise.wwwapi.DataModels.Payloads
{
    public class StudentPayloads
    {

        public record StudentPostPayload(string first_name, string last_name, DateTimeOffset d_o_b);
        public record StudentPutPayload(string? first_name, string? last_name, DateTimeOffset? d_o_b);
    }
}
