using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        
        [Column("lastname")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public string DateofBirth { get; set; }

        [Column("course")]
        public string CourseTitle { get; set; }

        [Column("start_date")]
        public DateTime Startdate { get; set; }

        [Column("avg_grade")]
        public double AvgGrade { get; set; }

        [ForeignKey("course_fk")]
        public int CourseId { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }            

        
    }
}
