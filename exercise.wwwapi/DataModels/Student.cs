using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student : Entity
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth"), DataType("date")]
        public DateTime DateOfBirth { get; set; }
        [Column("course_id")]
        public IEnumerable<Course> Courses { get; } = [];
        public IEnumerable<StudentCourse> StudentCourses { get; } = [];

    }
}
