using exercise.wwwapi.Models.Interfaces;

namespace exercise.wwwapi.Models.Models.Courses
{
    public class CoursePut : ICourse
    {
        public string CourseTitle { get; set; } = "";
        public DateOnly StartDate { get; set; }
    }
}
