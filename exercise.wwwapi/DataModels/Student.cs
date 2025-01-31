using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Column("email")]
        [MaxLength(255)]
        public required string Email { get; set; }
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
    }
}
