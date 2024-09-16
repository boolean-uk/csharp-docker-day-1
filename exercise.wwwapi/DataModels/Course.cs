using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("Id")]
        public int Id { get; set; }

        public string CourseTitle { get; set; }

        public DateTime StartDate { get; set; }

        public int AverageGrade { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
