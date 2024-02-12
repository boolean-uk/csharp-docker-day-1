using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student_course")]
    public class StudentCourse : Entity
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("avg_grade")]
        public float AvgGrade { get; set; }
    }
}
