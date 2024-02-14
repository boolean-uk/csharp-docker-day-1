using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Key, Column("id")]
        public int Id { get; set; }
        
        [Column("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }

        /*

        [Column("name")]
        public string Name { get; set; }

        [Column("startdate")]
        public DateTime CourseStartDate { get; set; }*/
    }
}
