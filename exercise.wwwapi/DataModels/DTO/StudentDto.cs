namespace exercise.wwwapi.DataModels.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AverageGrade { get; set; }
        public IEnumerable<CourseListDto> Courses { get; set; }
    }
}
