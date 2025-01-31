namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; } = [];
        public List<StudentCourse> StudentCourses { get; } = [];
    }
}
