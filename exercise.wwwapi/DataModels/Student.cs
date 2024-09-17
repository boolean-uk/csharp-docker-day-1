using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public int Id { get; set; }

        [Column("first_names")]
        public string FirstName { get; set; }
        
        
        [Column("last_names")]
        public string LastName { get; set; }


        [Column("dates_of_birth")]
        public DateOnly DateOfBirth { get; set; }


        [ForeignKey("courses")]
        [Column("course_id's")]
        public List<int> CourseIds { get; set; } = new List<int>();


        [Column("average_grades")]
        public int AverageGrade { get; set; }

    }
}
