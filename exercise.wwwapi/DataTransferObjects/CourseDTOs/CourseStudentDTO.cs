namespace exercise.wwwapi.DataTransferObjects.CourseDTOs
{
    public class CourseStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AvgGrade { get; set; }
    }
}
