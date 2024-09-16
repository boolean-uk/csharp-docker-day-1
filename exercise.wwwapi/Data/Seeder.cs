using exercise.wwwapi.DataModels;
using System;

namespace exercise.wwwapi.Data
{
    public class Seeder
    {
        private List<Student> _students = new List<Student>();
        private List<CourseDTO> _courses = new List<CourseDTO>();

        private List<string> _firstNames = new List<string>()
        {
            "Felix",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Adam",
            "Mickey",
            "Kate",
            "Charles",
            "Arnold",
            "Ragnar",
            "Neo"
        };

        private List<string> _lastNames = new List<string>()
        {
            "Mathiasson",
            "Duck",
            "Presley",
            "Obama",
            "Winfrey",
            "Sandler",
            "Mouse",
            "Winslow",
            "Xavier",
            "Schwarzenegger",
            "Lothbrok",
            "Andersson"
        };

        private List<string> _courseSelection = new List<string>()
        {
            "Maths",
            "Science",
            "Litterature",
            "Arts and crafts",
            "PE",
            "Social sciences",
            "Pyschology",
            "Programming",
            "Physics",
            "History"
        };

        private DateOnly GetRandomDateOnly(Random random, int startYear, int endYear)
        {
            int year = random.Next(startYear, endYear + 1);

            int month = random.Next(1, 13);

            int daysInMonth = DateTime.DaysInMonth(year, month);
            int day = random.Next(1, daysInMonth + 1);

            return new DateOnly(year, month, day);
        }
        private DateOnly RandomizeDate()
        {
            int startYear = 2022;
            int endYear = 2030;

            Random random = new Random();
             return GetRandomDateOnly(random, startYear, endYear);
        }


        public Seeder()
        {
            Random random1 = new Random();
            Random random2 = new Random();

            for(int i = 1; i < 11; i++)
            {
                Student student = new Student();
                student.Id = i;
                student.FirstName = _firstNames[random1.Next(_firstNames.Count)];
                student.LastName = _lastNames[random2.Next(_lastNames.Count)];
                student.AverageGrade = random1.Next(1, 5 + 1);
                student.DateOfBirth = RandomizeDate();
                student.CourseIds.Add(i);
                _students.Add(student);
            }

            for(int i = 1; i < 11; i++)
            {
                CourseDTO course = new CourseDTO();
                course.Id = i;
                course.StartDateForCourse = RandomizeDate();
                course.CourseTitle = _courseSelection[i - 1];
                _courses.Add(course);
            }
        }

        public List<Student> Students { get { return _students; } }
        public List<CourseDTO> Courses { get { return _courses; }  }
    }
}
