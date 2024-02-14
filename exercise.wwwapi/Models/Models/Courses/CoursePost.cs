using exercise.wwwapi.Models.Interfaces;

namespace exercise.wwwapi.Models.Models.Courses
{
    public class CoursePost : ICourse
    {
        public string CourseTitle { get; set; } = "";
        public DateOnly StartDate { get; set; }
    }
}
