using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class GetStudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public int AvgGrade { get; set; }
        public List<EnrollmentDTO> StudentsCourses { get; set; } = new List<EnrollmentDTO>();
        public GetStudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DoB = student.DoB;
            AvgGrade = student.AvgGrade;
            foreach(var enrollment in student.Enrollments)
            {
                StudentsCourses.Add(new EnrollmentDTO(enrollment));
            }
        }
        public static List<GetStudentDTO> FromRepository(IEnumerable<Student> students)
        {
            var results = new List<GetStudentDTO>();
            foreach (var student in students)
            {
                results.Add(new GetStudentDTO(student));
            }
            return results;
        }

    }
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public List<StudentsEnrolledDTO> Students { get; set; } = new List<StudentsEnrolledDTO>();
        public GetCourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            StartDate = course.StartDate;
            foreach (var enrollment in course.Students)
            {
                Students.Add(new StudentsEnrolledDTO(enrollment));
            }
        }
        public static List<GetCourseDTO> FromRepository(IEnumerable<Course> courses)
        {
            var results = new List<GetCourseDTO>();
            foreach (var course in courses)
            {
                results.Add(new GetCourseDTO(course));
            }
            return results;
        }
    }
    public class GetEnrollmentsDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public GetEnrollmentsDTO(Join_student_course enrollment)
        {
            StudentId = enrollment.StudentId;
            CourseId = enrollment.CourseId;
        }
    }
    public class StudentsEnrolledDTO
    {
        public StudentDTO Student { get; set; }
        public StudentsEnrolledDTO(Join_student_course student)
        {
            Student = new StudentDTO(student.Student);
        }
    }
    public class EnrollmentDTO
    {
        public CourseDTO Course { get; set; }
        public EnrollmentDTO(Join_student_course enrollment)
        {
            Course = new CourseDTO(enrollment.Course);
        }
    }
    public class CourseDTO
    {
        public int Id { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public CourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Description = course.Description;
            StartDate = course.StartDate;
        }
    }
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public int AvgGrade { get; set; }
        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DoB = student.DoB;
            AvgGrade = student.AvgGrade;
        }
    }
}
