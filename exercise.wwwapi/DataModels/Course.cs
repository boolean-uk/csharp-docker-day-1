using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
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

        [Column("average_grade")]
        [Required]
        public char AverageGrade { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }
    }
}
