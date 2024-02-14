using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("average_grade")]
        public string AverageGrade { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }
    }

    public class CoursePost
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public string AverageGrade { get; set; }
    }
}
