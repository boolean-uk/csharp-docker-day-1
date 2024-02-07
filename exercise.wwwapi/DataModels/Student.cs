using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("dob")]
        public string DoB { get; set; }
        [Column("avg_grade")]
        public int AvgGrade { get; set; }
        //[Column("course_id")]
        //public int CourseId { get; set; }
        //public virtual Course Course { get; set; }

        //public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Join_student_course> Enrollments { get; set; }
    }
}