namespace workshop.wwwapi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
        public int Age { get; set; }
        public List<CoursePerson> CoursePersons { get; set; } = [];
        public List<Course> Courses { get; set; } = [];

        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
