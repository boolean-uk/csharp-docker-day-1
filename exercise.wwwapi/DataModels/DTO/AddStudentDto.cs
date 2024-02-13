namespace exercise.wwwapi.DataModels.DTO
{
    public class AddStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string AverageGrade { get; set; }
    }
}
