using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{

    [Table("students")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("birthdate")]
        public DateOnly BirthDate { get; set; }

        [ForeignKey("courses")]
        public List<int> CourseId { get; set; } = new List<int>();

        [Column("average_grades")]
        public int AverageGrade { get; set; }

    }
}
