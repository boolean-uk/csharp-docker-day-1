namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
        public Guid CourseId { get; set; }
    }
}
