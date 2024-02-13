namespace exercise.wwwapi.DataTransferObjects.StudentDTOs
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public StudentCourseDTO Course { get; set; }
        public decimal AvgGrade { get; set; }
    }
}
