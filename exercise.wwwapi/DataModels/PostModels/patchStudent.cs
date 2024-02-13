namespace exercise.wwwapi.DataModels.PostModels
{
    public class PatchStudent
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CourseId { get; set; }
        public DateTime? CourseDate { get; set; }
        public double? AverageGrade { get; set; }
    }
}
