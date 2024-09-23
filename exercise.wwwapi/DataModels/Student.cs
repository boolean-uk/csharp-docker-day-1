using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstName")]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("dateOfBirth")]
        public DateTime DOB { get; set; }

        [ForeignKey("courses")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
