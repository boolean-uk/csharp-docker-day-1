namespace exercise.wwwapi.DataTransferObjects
{
    public class GetStudentDTO
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? CourseTitle {  get; set; } 
        public double AverageGrade { get; set; }
    }
}
