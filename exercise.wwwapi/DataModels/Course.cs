using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Column("courseTitle")]
        public string CourseTitle { get; set; }
        [Column("courseStartDate")]
        public string CourseStartDate { get; set; }
        [Column("averageGrade")]
        public double AverageGrade { get; set; }
        [JsonIgnore]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
