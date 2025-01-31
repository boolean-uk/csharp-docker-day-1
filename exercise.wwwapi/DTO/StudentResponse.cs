namespace exercise.wwwapi.DTO;

public class StudentResponse : Student
{
    public IEnumerable<Course> Courses { get; set; }
}