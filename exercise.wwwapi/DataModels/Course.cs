using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Column("credits")]
        public int Credits { get; set; }
        [Column("department")]
        [MaxLength(100)]
        public required string Department { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
