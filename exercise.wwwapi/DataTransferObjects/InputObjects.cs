namespace exercise.wwwapi.DataTransferObjects
{
    public class InputCourse
    {
        public string CourseName { get; set; }
        public double AverageGrade { get; set; }
        public DateTime StartDate { get; set; }
    }
    public class InputStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int courseId { get; set; }
    }
}
