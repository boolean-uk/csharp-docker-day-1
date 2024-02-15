namespace exercise.wwwapi.DataTransferObjects.Request
{
    public class StudentRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageGrade { get; set; }
        public int CourseId { get; set; }
    }
}
