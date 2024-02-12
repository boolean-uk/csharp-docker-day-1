using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course : Entity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("student_id")]
        public IEnumerable<Student> Students { get; } = [];
        public IEnumerable<StudentCourse> StudentCourses { get; } = [];
    }
}
