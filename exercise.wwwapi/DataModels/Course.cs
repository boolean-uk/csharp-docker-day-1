using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        public int Id { get; set; }
    }
}
