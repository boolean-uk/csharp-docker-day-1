using exercise.wwwapi.DataModels;

public class StudentDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<CourseStudentDTO> Courses { get; set; }

    public StudentDTO(Student student)
    {
        Id = student.Id;
        FirstName = student.FirstName;
        LastName = student.LastName;
        DateOfBirth = student.BirthDate;
        Courses = CourseStudentDTO.FromRepository(student.Courses);
    }

    public static List<StudentDTO> FromRepository(IEnumerable<Student> results)
    {
        return results.Select(s => new StudentDTO(s)).ToList();
    }
}

public class CourseStudentDTO
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public string AverageGrade { get; set; }

    public CourseStudentDTO(Course course)
    {
        Id = course.Id;
        Title = course.Title;
        StartDate = course.StartDate;
        AverageGrade = course.AverageGrade;
    }

    public static List<CourseStudentDTO> FromRepository(IEnumerable<Course> courses)
    {
        return courses.Select(c => new CourseStudentDTO(c)).ToList();
    }
}