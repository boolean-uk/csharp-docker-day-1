using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        public List<StudentDTO> Students { get; set; }

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            StartDate = course.StartDate;
            Students = new List<StudentDTO>();
            if (course.CourseStudent != null && course.CourseStudent.Count() != 0)
            {
                foreach (var courseStudent in course.CourseStudent)
                {
                    var studentDto = new StudentDTO(courseStudent.Student);
                    Students.Add(studentDto);
                }
            }

        }

        public static List<CourseResponseDTO> FromRepository(IEnumerable<Course> courses)
        {
            var results = new List<CourseResponseDTO>();
            if (courses.Count() != 0)
            {
                foreach (var course in courses)
                {
                    results.Add(new CourseResponseDTO(course));
                }
            }
            return results;
        }


        public static CourseResponseDTO FromRepository(Course course)
        {
            return new CourseResponseDTO(course);
        }
    }
}