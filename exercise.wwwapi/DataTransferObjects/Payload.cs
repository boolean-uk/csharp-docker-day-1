using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }
    public record StudentPostPayload(string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade);
    public record StudentUpdatePayload(string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade);
}
