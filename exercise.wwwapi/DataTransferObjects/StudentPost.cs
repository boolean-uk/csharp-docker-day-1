namespace exercise.wwwapi.DataModels
{
    public class StudentPost
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CourseId { get; set; }
        public DateTime? StartDate { get; set; }
        public double? AverageGrade { get; set; }
    }
}
