using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class CourseData
    {
        public List<Course> Courses { get; set; } = new List<Course>()
        {
            new Course(){ Title = "C#" },
            new Course(){ Title = "Java" },
        };
    }
}
