using System.Security.Cryptography.Xml;

namespace exercise.wwwapi.DataTransferObjects
{
    public record CreateStudentPayload(string FirstName, string LastName, DateTime DOB, int AverageGrade);

    public record CreateCoursePayload(string Title, string Teacher, DateTime StartDate);

    public record StudentUpdatePayload(string? FirstName, string? LastName, DateTime? DOB, int? AverageGrad);

    public record CourseUpdatePayload(string? Title, string? Teacher, DateTime? StartDate);

    public record CreateCourseStudentPayload(int courseId, int studentId);
}
