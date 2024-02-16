using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataModels
{
    public class StudentPost : IStudent
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CourseId { get; set; }
    }
}
