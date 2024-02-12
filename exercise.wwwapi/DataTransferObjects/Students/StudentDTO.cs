using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.Students
{
    public class StudentDTO(Student student)
    {
        public int Id { get; set; } = student.Id;

        public string FirstName { get; set; } = student.FirstName;

        public string LastName { get; set; } = student.LastName;

        public string DateOfBirth { get; set; } = student.DateOfBirth.ToString("yyyy-MM-dd");

        public double AverageGrade { get; set; } = student.AverageGrade;

        public StudentCourseDTO CourseInformation { get; set; } = new StudentCourseDTO(student.Course);
    }
}
