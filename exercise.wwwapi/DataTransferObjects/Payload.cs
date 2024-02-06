namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }

    public record CreateNewStudentPayload
    (
        string? FirstName,
        string? LastName,
        string? DateOfBirth,
        string? CourseTitle,
        string? CourseStartDate,
        int AverageGrade
    );

    public record UpdateStudentPayload
(
    string? FirstName,
    string? LastName,
    string? DateOfBirth,
    string? CourseTitle,
    string? CourseStartDate,
    int AverageGrade
);
}
