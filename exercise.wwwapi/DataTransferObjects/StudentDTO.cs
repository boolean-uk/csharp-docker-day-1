namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();

        public int AverageGrade { get; set; }
    }
}
