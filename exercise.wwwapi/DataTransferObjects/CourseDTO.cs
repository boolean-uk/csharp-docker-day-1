using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DTO
{
    public class CourseClassDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TutorName { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public List<StudentForCourseDTO> Students { get; set; }

        public CourseClassDTO(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            Id = course.Id;
            CourseName = course.CourseName;
            TutorName = course.TutorName;
            StartDate = course.StartDate;
            Capacity = course.Capacity;
            Location = course.Location;
            Students = course.students?.Select(s => new StudentForCourseDTO
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                DateOfBirth = s.DateOfBirth,
                AverageGrade = s.AvarageGrade
            }).ToList() ?? new List<StudentForCourseDTO>();
        }
        public static List<CourseClassDTO> FromListOfCourses(List<Course> courses)
        {
            if (courses == null)
            { throw new ArgumentNullException(nameof(courses));}

            return courses.Select(course => new CourseClassDTO(course)).ToList();
        }
    }
    public class StudentForCourseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float AverageGrade { get; set; }
    }
}