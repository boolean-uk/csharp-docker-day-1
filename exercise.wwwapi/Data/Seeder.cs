using exercise.wwwapi.DataModels;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<Course> _courses = new List<Course>();
        private List<Student> _students = new List<Student>();
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate",
            "Arthur",
            "Emma"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton",
            "Jacobsen",
            "Olsen"

        };
        private List<int> day = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28
        };
        private List<int> month = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12
        };
        private List<int> hrs = new List<int>()
        {
            8,9,10,11
        };
        private List<int> min = new List<int>()
        {
            0,10,20,30,40,50
        };

        public Seeder()
        {
            Random dateRandom = new Random();
            _courses.Add(new Course() { Id = -1, Title = "Not Specified" });
            _courses.Add(new Course() { Id = 1, Title = "C#" });
            _courses.Add(new Course() { Id = 2, Title = "Java" });
            _courses.Add(new Course() { Id = 3, Title = "C" });

            for (int i = 1; i < 30; i++)
            {
                Student student = new Student();
                student.Id = i;
                student.FirstName = _firstnames[new Random().Next(_firstnames.Count)];
                student.LastName = _lastnames[new Random().Next(_lastnames.Count)];
                student.CourseDate = DateTime.SpecifyKind(new DateTime(2024, month[dateRandom.Next(12)], day[dateRandom.Next(28)]), DateTimeKind.Utc);
                student.AverageGrade = Math.Round(new Random().NextDouble() * 10,2);
                student.DateOfBirth = DateTime.SpecifyKind(new DateTime(new Random().Next(1970,2010), month[dateRandom.Next(12)], day[dateRandom.Next(28)]),DateTimeKind.Utc);
                student.CourseId = new Random().Next(_courses.Count-1)+1;
                _students.Add(student);
            }

        }

        public List<Course> Courses { get {  return _courses; } }
        public List<Student> Students { get { return _students; } }


    }

}
