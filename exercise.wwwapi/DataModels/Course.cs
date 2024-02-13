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
        [Column("average_grade")]
        public double AverageGrade { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
