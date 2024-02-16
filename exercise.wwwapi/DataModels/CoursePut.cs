using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataModels
{
    public class CoursePut : ICourse
    {
        public string CourseTitle { get; set; } = "";

        public char AverageGrade { get; set; } = 'å';

        public DateTime StartDate { get; set; } = DateTime.MinValue;
    }
}
