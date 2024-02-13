using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("started_at")]
        public DateTime StartedAt { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
