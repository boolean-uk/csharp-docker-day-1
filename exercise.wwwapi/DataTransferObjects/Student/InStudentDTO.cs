namespace exercise.wwwapi.DataTransferObjects.Student
{
    public class InStudentDTO
    {
      
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DoB { get; set; }
        public double? AverageGrade { get; set; }

        public int CourseId { get; set; }

    }
}
