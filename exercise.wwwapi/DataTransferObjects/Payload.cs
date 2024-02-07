using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }
    public record StudentPostPayload(string FirstName, string LastName, string Dob, int CourseId, int AvgGrade);
    public record StudentUpdatePayload(string FirstName, string LastName, string Dob, int CourseId, int AvgGrade);
    public record CoursePostPayload(string Title, string Description, string StartDate);
    public record CourseUpdatePayload(string Title, string Description, string StartDate);
    public record EnrollmentPostPayload(int StudentId, int CourseId);
}
