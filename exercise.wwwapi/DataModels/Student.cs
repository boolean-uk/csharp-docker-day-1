using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}
