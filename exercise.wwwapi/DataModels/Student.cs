using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using exercise.wwwapi.DataModels.DTO;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Column("id")] public int Id { get; set; }
        [Column("course_id")][ForeignKey("course_id")] public int CourseId { get; set; }
        [Column("first_name")] public string FirstName { get; set; }
        [Column("last_name")] public string LastName { get; set; }
        [Column("dob")] public DateTime Dob { get; set; }
        [Column("course_title")] public string CourseTitle { get; set; }
        [Column("course_start_date")] public DateTime CourseStart { get; set; }
        [Column("avr_score")] public double AverageScore { get; set; }

        //[JsonIgnore]
        //public Course CurCourse { get; set; }




    }
}
