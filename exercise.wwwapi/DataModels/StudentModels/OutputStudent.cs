using exercise.wwwapi.DataModels.CourseModels;

namespace exercise.wwwapi.DataModels.StudentModels
{
    public class OutputStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double AverageGrade { get; set; }

        public CourseWhitoutStudents Course { get; set; }
    }
}
