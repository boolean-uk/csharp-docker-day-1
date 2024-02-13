namespace exercise.wwwapi.DataModels.Course;

public class CourseDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public static CourseDTO ToDTO(Course course)
    {
        return new CourseDTO { Id = course.Id, Title = course.Title };
    }
