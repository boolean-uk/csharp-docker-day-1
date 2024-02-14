namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? StartDate { get; set; }
        public double? AverageGrade { get; set; }
    }
}
