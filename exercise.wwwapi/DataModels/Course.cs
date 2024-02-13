using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course : IClass
    {
        [Key]
        [Column("course_id")]
        public int Id { get; set; }

        [Column("course_title")]
        public string Title { get; set; }

        [Column("start_date_course", TypeName = "Date")]
        public DateTime? CourseStartDate { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
       
    }
}
