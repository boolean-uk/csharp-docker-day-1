using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student_courses")]
    [PrimaryKey("Id")]
    public class StudentCourse
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("student_id")]
        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }
        [Column("course_id")]
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        [Column("grade")]
        [Required]
        public char Grade { get; set; }

    }
}
