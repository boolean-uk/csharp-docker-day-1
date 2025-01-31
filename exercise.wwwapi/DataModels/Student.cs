using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }

        [JsonIgnore]
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
