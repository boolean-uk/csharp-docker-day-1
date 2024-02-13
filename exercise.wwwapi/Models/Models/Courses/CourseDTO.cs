using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.StudentCourses;

namespace exercise.wwwapi.Models.Models.Courses
{
    public class CourseDTO : ICourse
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = "";
        public DateOnly StartDate { get; set; }
        public ICollection<StudentCourseForCourseDTO> StudentCourses { get; set; } = new List<StudentCourseForCourseDTO>();
    }
}
