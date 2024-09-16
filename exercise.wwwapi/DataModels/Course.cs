using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Course")]
    public class Course
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("AverageGrade")]
        public double AverageGrade { get; set; }
    }
}
