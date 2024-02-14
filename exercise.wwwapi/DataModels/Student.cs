using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("firstName")]
        public string FirstName { get; set; }
        [Column("lastName")]
        public string LastName { get; set; }
        [Column("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("averageGrade")]
        public string AverageGrade { get; set; }
        [Column("courses")]
        public IEnumerable<Course> Courses { get; set; }
        
    }
}
