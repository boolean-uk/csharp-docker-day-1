namespace exercise.wwwapi.DataTransferObjects
{
    public class PutStudent
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? CourseTitle { get; set; }

        public double? AverageGrade { get; set; }
    }
}
