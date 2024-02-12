using System.ComponentModel.DataAnnotations.Schema;
using exercise.wwwapi.DataModels.StudentModels;

namespace exercise.wwwapi.DataModels.CourseModels
{
    [Table("course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("startDate")]
        public DateTime Starts { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
