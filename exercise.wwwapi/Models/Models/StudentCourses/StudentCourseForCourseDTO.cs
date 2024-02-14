using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;

namespace exercise.wwwapi.Models.Models.StudentCourses
{
    public class StudentCourseForCourseDTO
    {
        public StudentLiteDTO Student { get; set; }
        public char Grade { get; set; }
    }
}
