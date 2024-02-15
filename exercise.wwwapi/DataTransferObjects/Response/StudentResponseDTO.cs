namespace exercise.wwwapi.DataTransferObjects.Response
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageGrade { get; set; }
        public string CourseTitle { get; set; }
    }
}
