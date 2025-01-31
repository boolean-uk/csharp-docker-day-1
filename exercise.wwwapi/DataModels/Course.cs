using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
