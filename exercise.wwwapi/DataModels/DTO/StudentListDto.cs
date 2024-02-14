namespace exercise.wwwapi.DataModels.DTO
{
    public class StudentListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AverageGrade { get; set; }
    }
}
