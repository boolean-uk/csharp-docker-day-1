using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataModels
{
    public class CoursePost : ICourse
    {
        public string CourseTitle { get; set; }

        public char AverageGrade { get; set; }

        public DateTime StartDate { get; set; }
    }
}
