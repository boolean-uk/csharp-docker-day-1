using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Column("id")] public int Id { get; set; }
        [Column("course_name")] public string CourseName { get; set; }
    }
}
