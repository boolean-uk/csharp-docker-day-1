using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("couses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
