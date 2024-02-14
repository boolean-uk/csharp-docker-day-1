using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;

namespace exercise.wwwapi.Models.Models.StudentCourses
{
    public class StudentCourseForStudentDTO
    {
        public CourseLiteDTO Course { get; set; }
        public char Grade { get; set; }
    }
}
