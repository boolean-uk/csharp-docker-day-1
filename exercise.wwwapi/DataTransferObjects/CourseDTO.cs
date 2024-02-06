using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }

        public CourseDTO(Course course)
        {
            this.Id = course.Id;
            this.Title = course.Title;
            this.StartDate = course.StartDate;
        }

        public static List<CourseDTO> FromCourses(IEnumerable<Course> courses)
        {
            var results = new List<CourseDTO>();
            foreach (var course in courses)
            {
                results.Add(new CourseDTO(course));
            }
            return results;
        }
    }

    public class CourseListResponseDTO
    {
        public List<CourseDTO> courses { get; set; }
        public CourseListResponseDTO(IEnumerable<Course> courses)
        {
            this.courses = new List<CourseDTO>();
            foreach (var course in courses)
            {
                this.courses.Add(new CourseDTO(course));
            }
        }
    }
}