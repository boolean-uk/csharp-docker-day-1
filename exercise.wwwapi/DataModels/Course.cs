using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("courseTitle")]
        public string CourseTitle { get; set; }

        [Column("courseStart")]
        public DateTime CourseStart { get; set; }

        [JsonIgnore]
        public List<Student> Students { get; set; }

    }
}
