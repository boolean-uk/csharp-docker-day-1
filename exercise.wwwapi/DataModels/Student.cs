using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        [Column("birthdate")]
        public required DateTime Birthdate { get; set; }

        [Column("average_grade")]
        public required float AverageGrade { get; set; }

        [ForeignKey("Course")]
        [Column("course_id")]
        public int? CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
