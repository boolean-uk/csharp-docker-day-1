namespace exercise.wwwapi.DataModels.DTO
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public IEnumerable<StudentListDto> Students { get; set; }

    }
}
