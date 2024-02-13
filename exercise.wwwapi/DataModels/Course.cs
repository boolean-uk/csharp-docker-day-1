using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course : Entity
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("student_id")]
        public List<Student> Students { get; } = [];
        public List<StudentCourse> StudentCourses { get; } = [];
    }
}
