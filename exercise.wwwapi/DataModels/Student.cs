namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DoB { get; set; }
    }
}
