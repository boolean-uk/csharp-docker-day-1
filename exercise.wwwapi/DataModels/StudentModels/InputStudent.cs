namespace exercise.wwwapi.DataModels.StudentModels
{
    public class InputStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double AverageGrade { get; set; }

        public int CourseId { get; set; }
    }
}
