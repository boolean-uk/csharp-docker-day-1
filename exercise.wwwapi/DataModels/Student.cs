using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("firstname")]
        public string? FirstName { get; set; }

        [Required]
        [Column("lastname")]
        public string? LastName { get; set; }

        [Required]
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column("coursetitle")]
        public string? CourseTitle { get; set; }

        [Required]
        [Column("startdate")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("averagegrade")]
        public double AverageGrade { get; set; }

        [Required]
        [ForeignKey("course")]
        [Column("courseid")]
        public Guid CourseId { get; set; }

        // Navigation property
        public Course course { get; set; }
    }
}
