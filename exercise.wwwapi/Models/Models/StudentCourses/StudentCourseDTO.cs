using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Models.Models.StudentCourses
{
    public class StudentCourseGenericDTO
    {
        public class StudentCourse : IStudentCourse
        {
            public StudentLiteDTO Student { get; set; }
            public CourseLiteDTO Course { get; set; }
            public char Grade { get; set; }
        }
    }
}
