

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("dateofbirth")]
        public string DateOfBirth { get; set; }

        [ForeignKey("courseId")]
        public int CourseId { get; set; }
        [JsonIgnore]
        public Course Course { get; set; }


    }
}
