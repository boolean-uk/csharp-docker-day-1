using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("courseStudent")]
    public class CourseStudent
    {
        [ForeignKey("courseId")]
        public int CourseId { get; set; }
        [ForeignKey("studentId")]
        public int StudentId { get; set;}
        [JsonIgnore]
        public Student Student { get; set;}
        [JsonIgnore]
        public Course Course { get; set;}
    }
}
