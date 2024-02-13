namespace exercise.wwwapi.DataTransferObjects.StudentDTOs
{
    public class UpdateStudentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CourseId { get; set; }
        public decimal? AvgGrade { get; set; }
    }
}
