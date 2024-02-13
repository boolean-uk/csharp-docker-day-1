using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("birthdate")]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey(nameof(Course))]
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Column("avg_grade")]
        public decimal AvgGrade { get; set; }
    }
}
