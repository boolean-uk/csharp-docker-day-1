namespace exercise.wwwapi.DataTransferObjects.InputDTOs
{
    public class StudentInputPutDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? CourseId { get; set; }

        public double? AverageGrade { get; set; }
    }
}
