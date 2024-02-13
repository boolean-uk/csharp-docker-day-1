using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }

        [JsonIgnore]
        public int StudentCount { get; set; }
      
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public object DtCourse()
        {
            return new { Id, Title, StudentCount = Students.Count };
        }
    }
}
