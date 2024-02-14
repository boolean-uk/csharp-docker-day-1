using exercise.wwwapi.Models.Interfaces;

namespace exercise.wwwapi.Models.Models.Courses
{
    public class CourseLiteDTO : ICourse
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = "";
        public DateOnly StartDate { get; set; }
    }
}
