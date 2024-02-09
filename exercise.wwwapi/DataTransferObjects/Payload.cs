namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }

    public record StudentPayload
    (
        string? FirstName,
        string? LastName,
        string? DateOfBirth,
        int AverageGrade,
        int courseId
    );
}
