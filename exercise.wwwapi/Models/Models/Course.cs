using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models.Models
{
    [Table("courses")]
    [PrimaryKey("Id")]
    public class Course
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("course_title")]
        [Required]
        public string CourseTitle { get; set; } = "";
        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
