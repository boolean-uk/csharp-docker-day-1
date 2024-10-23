using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname")] 
        public string firstName { get; set; }
        [Column("lastname")]
        public string lastName { get; set; }
        [Column("dateofbirth")]
        public DateTime dateOfBirth { get; set; }

        [ForeignKey("course")]
        [Column("course_id")]
        public int courseId { get; set; }
        public Course course { get; set; }
    }
}
