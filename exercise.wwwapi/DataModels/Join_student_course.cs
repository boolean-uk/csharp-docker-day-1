using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Students_Courses")]
    public class Join_student_course
    {
        [Column("student_id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
