using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }


        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course Course { get; set;}

        public Student() { }
        public Student(PostStudent student)
        {
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
            CourseId = student.CourseId;
        }

    }

    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public StudentDto(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
        }
    }

    public class GetStudentDto : StudentDto
    {
        public CourseDto Course { get; set; }

        public GetStudentDto(Student student) : base(student) 
        {
            Course = new CourseDto(student.Course);
        }
    }

    public class PostStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int CourseId { get; set; }
    }
}
