namespace exercise.wwwapi.DataTransferObjects
{
    public class Payload
    {
        public record CreateStudentPayload(string FirstName, string LastName, string DateOfBirth, string CourseTitle, DateTime StartDate, float Grade);
        public record UpdateStudentPayload(string FirstName, string LastName, string DateOfBirth, string CourseTitle, DateTime StartDate, float Grade);
    }
}
