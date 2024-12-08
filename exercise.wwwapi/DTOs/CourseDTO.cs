namespace exercise.wwwapi.DTOs
{
    public class CourseDTO
    {
        public string ?Name { get; set; }
        public ICollection<StudentDTO> Students { get; set; }
    }
}
