using exercise.wwwapi.DataModels;
namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }

    public record CreateStudentPayload(string FirstName, string LastName, DateOnly DateOfBirth);
    public record CreateEnrollmentPayload(int studentId, int courseId, int academicYear);
    public record UpdateStudentPayload(int studentId, string newFirstName, string newLastName, DateOnly newDateOfBirth);
}

