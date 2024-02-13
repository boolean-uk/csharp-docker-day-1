namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int CourseId {  get; set; }
        public string CourseName { get; set; }
        public double AverageGrade { get; set; }
        public DateTime StartDate { get; set; } 
        public ICollection<StudentsForCourseDTO> Students { get; set; } = new List<StudentsForCourseDTO>();
    }

    public class StudentsForCourseDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
