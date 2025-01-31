using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
