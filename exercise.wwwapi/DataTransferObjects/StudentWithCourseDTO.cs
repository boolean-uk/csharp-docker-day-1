using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentWithCourseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public CourseWithNoStudentsDTO Course { get; set; }
    }
}
