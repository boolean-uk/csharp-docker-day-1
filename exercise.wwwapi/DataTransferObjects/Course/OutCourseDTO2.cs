using exercise.wwwapi.DataTransferObjects.Student;

namespace exercise.wwwapi.DataTransferObjects.Course
{
    public class OutCourseDTO2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? CourseStartDate { get; set; }

        public ICollection<OutStudentDTO> Students { get; set; } = new List<OutStudentDTO>();
    }
}
