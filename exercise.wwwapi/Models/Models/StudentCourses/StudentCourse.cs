using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.Courses;
using exercise.wwwapi.Models.Models.Students;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models.Models.StudentCourses
{
    [Table("student_courses")]
    [PrimaryKey("Id")]
    public class StudentCourse : IStudentCourse
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("student_id")]
        [ForeignKey("Student")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Column("course_id")]
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Column("grade")]
        [Required]
        public char Grade { get; set; }
    }
}
