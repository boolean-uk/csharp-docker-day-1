namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public int AveregeGrade { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();

    }
}
