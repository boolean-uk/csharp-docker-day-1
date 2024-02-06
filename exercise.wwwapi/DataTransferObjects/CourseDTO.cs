using exercise.wwwapi.DataModels;

public class CourseDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public string AverageGrade { get; set; }

    public CourseDTO(Course course)
    {
        Id = course.Id;
        Title = course.Title;
        StartDate = course.StartDate;
        AverageGrade = course.AverageGrade;
    }

    public static List<CourseDTO> FromRepository(IEnumerable<Course> courses) {
        return courses.Select(c => new CourseDTO(c)).ToList();
    }
}