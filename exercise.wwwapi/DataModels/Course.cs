namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; } = [];
    }
}
