using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student_course")]
    public class StudentCourse : Entity
    {
        [ForeignKey("Student"), Column("student_id")]
        public int StudentId { get; set; }

        [ForeignKey("Course"), Column("course_id")]
        public int CourseId { get; set; }

        [Column("start_date"), DataType("date")]
        public DateTime StartDate { get; set; }

        [Column("avg_grade")]
        public float AvgGrade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
