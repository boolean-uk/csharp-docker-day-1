using exercise.wwwapi.DataModels.CourseTypes;

namespace exercise.wwwapi.DataModels.StudentTypes;

public class StudentDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public CourseDTO Course { get; set; }
    public double AverageGrade { get; set; }
    public DateTime StartDate { get; set; }
    public static StudentDTO ToDTO(Student student)
    {
        return new StudentDTO()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            Course = CourseDTO.ToDTO(student.Course),
            AverageGrade = student.AverageGrade,
            StartDate = student.StartDate,
        };
    }
}
