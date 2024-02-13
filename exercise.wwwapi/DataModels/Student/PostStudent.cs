namespace exercise.wwwapi.DataModels.Student;

public class PostStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CourseId { get; set; }
    public int AverageGrade { get; set; }
    public DateTime StartDate { get; set; }
}
