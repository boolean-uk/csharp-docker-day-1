using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data.SeedData
{
    public class Seeder
    {
        private List<Course> _courses { get; set; } = new List<Course>();
        private List<Student> _students { get; set; } = new List<Student>();

        public Seeder() 
        {
            Course course = new Course()
            {
                Id = 1,
                CourseTitle = "Fullstack C#",
                CourseStartDate = DateTime.SpecifyKind(new DateTime(2024,01,07), DateTimeKind.Utc),
            };

            Student student = new Student()
            {
                Id = 1,
                FirstName = "Stian",
                LastName = "Gaustad",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 08, 20), DateTimeKind.Utc),
                CourseID = 1,
                AverageGrade = 3,
            };

            Student student2 = new Student()
            {
                Id = 2,
                FirstName = "Tølløv",
                LastName = "Aresvik",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1996, 04, 15), DateTimeKind.Utc),
                CourseID = 1,
                AverageGrade = 3,
            };

            _courses.Add(course);
            _students.Add(student);
            _students.Add(student2);


        }

        public List<Course> Courses { get { return _courses; } }
        public List<Student> Students { get {  return _students; } }
    }
}
