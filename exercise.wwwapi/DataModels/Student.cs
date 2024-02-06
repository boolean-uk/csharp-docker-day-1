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

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("course_title")]
        public string CourseTitle { get; set; }

        [Column("start_date")]
        public DateTime CourseStartDate { get; set; }

        [Column("average_grade")]
        public float AverageGrade { get; set; }
    }
}
