using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("startsAt", TypeName = "date")]
        public DateTime StartsAt { get; set; }
        [Column("averageGrade")]
        public char AverageGrade { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
