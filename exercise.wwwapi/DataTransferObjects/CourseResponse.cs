namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    }
}
