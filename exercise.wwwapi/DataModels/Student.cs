using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("dob")]
        public DateTime DoB { get; set; } 

        [Column("course_id")]
        [ForeignKey("course_id")]
        public int CourseId { get; set; }



        [JsonIgnore]
        public Course Course { get; set; }

    }
}
