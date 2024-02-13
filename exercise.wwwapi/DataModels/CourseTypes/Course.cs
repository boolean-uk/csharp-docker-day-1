using exercise.wwwapi.DataModels.StudentTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels.CourseTypes;

[Table("course")]
public class Course
{
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; }
    public ICollection<Student> Students { get; set; }
}
