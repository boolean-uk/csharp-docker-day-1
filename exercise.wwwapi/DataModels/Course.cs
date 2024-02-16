using System.Data;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start {  get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
