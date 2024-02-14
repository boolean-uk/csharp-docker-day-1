using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.StudentCourses;

namespace exercise.wwwapi.Models.Models.Students
{
    public class StudentDTO : IStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public ICollection<StudentCourseForStudentDTO> StudentCourses { get; set; } = new List<StudentCourseForStudentDTO>();
    }
}
