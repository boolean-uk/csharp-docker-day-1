using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    
    
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("course_name")]
        public string CourseName { get; set; }
        [Column("avg_grade")]
        public double AvgGrade { get; set; }
        [Column("start_of_course")]
        public DateTime StartOfCourse { get; set; }

        [JsonIgnore]
        public IEnumerable<Student> Students { get; set; } = new List<Student>();

    }
}
