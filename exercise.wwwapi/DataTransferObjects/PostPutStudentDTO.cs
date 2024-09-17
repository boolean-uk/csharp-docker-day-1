namespace exercise.wwwapi.DataTransferObjects
{
    public class PostPutStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseStart { get; set; }
        public double AverageGrade { get; set; }
    }
}
