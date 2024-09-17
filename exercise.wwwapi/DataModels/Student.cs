using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("dateofbirth")]
        public int DateOfBirth { get; set; }

        [Column("averageGrade")]
        public decimal AvgGrade { get; set; }

        [Column("courseId")]
        [ForeignKey("Course")]
        [JsonIgnore]
        public int CourseId { get; set; }
        public Course StudentCourse { get; set; }
    }
}
