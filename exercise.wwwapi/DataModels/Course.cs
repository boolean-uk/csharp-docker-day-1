using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("course_title")]
        public string Title { get; set; }

        [Column("course_date_started")]
        public DateTime CourseStart { get; set; } 

        [Column("average_grade")]
        public double AverageGrade { get; set; } 


    }
}
