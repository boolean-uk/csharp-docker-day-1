using System.Security.Cryptography.Xml;

namespace exercise.wwwapi.DataTransferObjects
{
    public record CreateStudentPayload(string FirstName, string LastName, DateTime DOB, int CourseId, int AverageGrade);

    public record CreateCoursePayload(string Title, DateTime StartDate);

    public record StudentUpdatePayload(string? FirstName, string? LastName, DateTime? DOB, int? CourseId, int? AverageGrad);

    public record CourseUpdatePayload(string? Title, DateTime? StartDate);
}
