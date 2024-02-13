using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("course_code")]
        public string CourseCode { get; set; }

        [Column("students")]
        public List<Student> Students { get; set; } = new List<Student>();



    }
}
