using exercise.wwwapi.DataModels.StudentModels;

namespace exercise.wwwapi.DataModels.CourseModels
{
    public class OutputCourse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Starts { get; set; }

        public IEnumerable<StudentWhitoutCourse> Students { get; set; }
    }
}
