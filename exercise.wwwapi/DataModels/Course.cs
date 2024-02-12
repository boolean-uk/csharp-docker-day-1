using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels;

[Table("course")]
public class Course
{
    [Column("id")]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; }
    public ICollection<Student> Students { get; set; }
}
