using exercise.wwwapi.DataModels.CourseTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels.StudentTypes;

[Table("student")]
public class Student
{
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
    [Column("cource_id")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    [Column("average_grade")]
    public double AverageGrade { get; set; }
    [Column("start_date")]
    public DateTime StartDate { get; set; }
}
