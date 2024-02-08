using exercise.wwwapi.DataModels;
namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }

    public record CreateStudentPayload(string FirstName, string LastName, DateOnly DateOfBirth, float avgGrade);
    public record CreateCoursePayload(string CourseTitle, DateOnly startdate);
    public record CreateEnrollmentPayload(int studentId, int courseId, int academicYear);
    public record UpdateStudentPayload(int studentId, string newFirstName, string newLastName, DateOnly newDateOfBirth, float avgGrade);
    public record UpdateCoursePayload(int courseId, string newTitle, DateOnly newStartDate);
}

