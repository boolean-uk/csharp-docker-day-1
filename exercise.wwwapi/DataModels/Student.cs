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
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("average_grade")]
        public decimal AverageGrade { get; set; }

        [Column("course_id")]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set;}
    }
}
