using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.Models.Models.Students;
using exercise.wwwapi.Models.Models.Courses;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentCourseDTO
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public char Grade { get; set; }
    }
}
