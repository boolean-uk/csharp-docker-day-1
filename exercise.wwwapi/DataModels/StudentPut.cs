using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataModels
{
    public class StudentPut : IStudent
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        public int CourseId { get; set; } = 0;
    }
}
