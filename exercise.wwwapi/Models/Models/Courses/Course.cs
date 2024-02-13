using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.StudentCourses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models.Models.Courses
{
    [Table("courses")]
    [PrimaryKey("Id")]
    public class Course : ICourse
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("course_title")]
        [Required]
        public string CourseTitle { get; set; } = "";
        [Column("start_date")]
        [Required]
        public DateOnly StartDate { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
