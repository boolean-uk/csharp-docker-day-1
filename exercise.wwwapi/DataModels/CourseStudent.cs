using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course_student")]
    public class CourseStudent
    {
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
