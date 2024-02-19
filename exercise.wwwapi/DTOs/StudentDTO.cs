namespace exercise.wwwapi.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CourseStudentDTO Course {  get; set; }

    }
    public class CourseStudentDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double AverageGrade { get; set; }
        public DateTime StartDate { get; set; }
    }
}
