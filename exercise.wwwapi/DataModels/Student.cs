using System.ComponentModel.DataAnnotations.Schema;


namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstName")]
        public string FirstName { get; set; }
        [Column("lastName")]
        public string LastName { get; set; }
        [Column("dateOfBirth", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column("courseId")]
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
