namespace exercise.wwwapi.DataTransferObjects
{
    
    public class Payload<T> where T : class
    {
        public T data { get; set; }
    }
  
    public record CreateStudentPayload(string FirstName, string LastName, string DateOfBirth, int AvrageGrade);

    public record UpdateStudentPayload(string FirstName, string LastName, string DateOfBirth, int AvrageGrade);

    public record CreateCoursePayload(string Title, string StartDate);

    public record UpdateCoursePayload(string Title, string StartDate);

    public record CreateOrUpdateStudentCoursePayload(int StudentId, int CourseId);

}
