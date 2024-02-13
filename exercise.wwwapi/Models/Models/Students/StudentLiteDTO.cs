using exercise.wwwapi.Models.Interfaces;

namespace exercise.wwwapi.Models.Models.Students
{
    public class StudentLiteDTO : IStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
    }
}
