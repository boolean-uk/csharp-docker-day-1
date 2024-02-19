namespace exercise.wwwapi.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double AvgGrade { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<StudentCourseDTO> Students { get; set; } = new List<StudentCourseDTO>();
    }

    public class StudentCourseDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
