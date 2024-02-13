using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student_course")]
    public class StudentCourse
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("avg_grade")]
        public string avgGrade { get; set; }

        [ForeignKey("course_fk"), Column("course_fk")]
        public int CourseId { get; set; }

        [ForeignKey("student_fk"), Column("student_fk")]
        public int StudentId { get; set; }
    }
}
