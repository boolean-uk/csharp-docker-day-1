using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
        
    public class Student
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("dob")]
        public DateTime DateOfBirth { get; set; }

        [Column("fk_course_id")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }
    }
}
