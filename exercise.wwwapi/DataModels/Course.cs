namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
        public List<Student> Students { get; set; }
        public Course() { }
        public Course(CoursePost post)
        {
            CourseTitle = post.CourseTitle;
            StartDate = post.StartDate;
            AverageGrade = post.AverageGrade;
            Students = new List<Student>();
        }
    }

    public class CoursePost
    {
        public string CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
    }

    public class CoursePut
    {
        public string? CourseTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public double? AverageGrade { get; set; }
    }

    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public double AverageGrade { get; set; }
        public CourseDto(Course course) 
        {
            Id = course.Id;
            CourseTitle = course.CourseTitle;
            StartDate = course.StartDate;
            AverageGrade = course.AverageGrade;
        }
    }

    public class CourseGet : CourseDto
    {
        public List<StudentDto> Students { get; set; }
        public CourseGet(Course course) : base(course)
        {
            Students = new List<StudentDto>();
            foreach(var student in course.Students)
            {
                Students.Add(new StudentDto(student));
            }
        }
    }
}
