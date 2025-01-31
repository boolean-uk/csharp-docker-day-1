using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student_course")]
    public class StudentCourse
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("student")]
        public int StudentId { get; set; }

        public Student student { get; set; }

        [ForeignKey("course")]
        public int CourseId { get; set; }

        public Course course { get; set; }
    }
}
