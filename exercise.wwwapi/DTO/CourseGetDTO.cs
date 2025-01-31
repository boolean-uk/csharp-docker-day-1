using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DTO
{
    public class CourseGetDTO
    {
        public string Name { get; set; }
        public List<StudentGetDTO> Student { get; }
        public List<StudentCourseDTO> StudentCourses { get; }
    }
}
