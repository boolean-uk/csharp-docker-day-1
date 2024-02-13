namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CourseForStudentDTO Course { get; set; }
    }

    public class CourseForStudentDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double AverageGrade { get; set; }
        public DateTime StartDate { get; set; }
    }
}
