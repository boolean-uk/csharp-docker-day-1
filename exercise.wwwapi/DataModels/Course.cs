using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
    }
}
