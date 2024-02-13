using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB {  get; set; }
        [Column("course_id")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Student() { }
        public Student(StudentPost student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            DoB = student.DoB;
            CourseId = student.CourseId;
        }
    }

    public class StudentPost
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public int CourseId { get; set; }
    }

    public class StudentPut
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DoB { get; set; }
        public int? CourseId { get; set; }
    }

    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public int CourseId { get; set; }
        public StudentDto(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DoB = student.DoB;
            CourseId = student.CourseId;
        }
    }

    public class StudentGet : StudentDto
    {
        public CourseDto Course { get; set; }
        public StudentGet(Student student) : base(student)
        {
            Course = new CourseDto(student.Course);
        }
    }
}
