namespace exercise.wwwapi.DTO;

public class CourseResponse : Course
{
    public IEnumerable<Student> Students { get; set; }
}