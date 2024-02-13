using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<Student> _students = new();
        private List<Course> _courses = new();

        private List<string> _firstnames = new()
        {
            "John",
            "Jane",
            "Michael",
            "Emily",
            "William",
            "Sophia",
            "James",
            "Olivia",
            "Robert",
            "Emma"
        };

        private List<string> _lastnames = new List<string>
        {
            "Smith",
            "Johnson",
            "Williams",
            "Jones",
            "Brown",
            "Davis",
            "Miller",
            "Wilson",
            "Moore",
            "Taylor"
        };


        private List<string> _coursePrefix = new List<string>
        {
            "Brave ",
            "Eternal ",
            "Mystic ",
            "Forgotten ",
            "Hidden ",
            "Lost ",
            "Magical ",
            "Forbidden ",
            "Enchanted ",
            "Legendary "
        };

        private List<string> _courseSuffix = new List<string>
        {
            "Dragon",
            "Hero",
            "Sorcerer",
            "Kingdom",
            "Empire",
            "Crystal",
            "Guardian",
            "Legend",
            "Treasure",
            "Prophecy"
        };

        Random random = new();

        public Seeder()
        {
            for(int i = 1; i <= 10; i++)
            {
                Course course = new();
                course.Id = i;
                course.Title = _coursePrefix[random.Next(_coursePrefix.Count)] + _courseSuffix[random.Next(_courseSuffix.Count)];
                course.AverageGrade = random.Next(600) / 100;
                course.StartDate = DateTime.UtcNow.AddDays(random.Next(100));
                _courses.Add(course);
            }

            for(int i = 1; i <= 30; i++)
            {
                Student student = new();
                student.Id = i;
                student.CourseId = _courses[random.Next(_courses.Count)].Id;
                student.FirstName = _firstnames[random.Next(_firstnames.Count)];
                student.LastName = _lastnames[random.Next(_lastnames.Count)];
                student.DOB = DateTime.UtcNow.AddDays(-8000-random.Next(2000));
                _students.Add(student);
            }
        }


        public List<Student> Students { get { return _students; } }
        public List<Course> Courses { get {  return _courses; } }
    }
}
