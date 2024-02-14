using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }


        public List<Student> Student { get; set; }

        public Course() { }
        public Course(PostCourse course)
        {
            Title = course.Title;
            StartDate = course.StartDate;
            AverageGrade = course.AverageGrade;
        }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }

        public CourseDto(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            StartDate = course.StartDate;
            AverageGrade = course.AverageGrade;
        }
    }

    public class GetCourseDto : CourseDto
    {
        public List<StudentDto> Student { get; set; } = new();

        public GetCourseDto(Course course) : base(course)
        {
            foreach (Student student in course.Student)
            {
                Student.Add(new StudentDto(student));
            }
        }
    }

    public class PostCourse
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
    }
}
