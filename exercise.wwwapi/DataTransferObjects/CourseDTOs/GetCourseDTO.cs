namespace exercise.wwwapi.DataTransferObjects.CourseDTOs
{
    public class GetCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartedAt { get; set; }
        public IEnumerable<CourseStudentDTO> Students { get; set; }
    }
}
