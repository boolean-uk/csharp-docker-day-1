using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int AvgGrade { get; set; }
        public List<CourseDTO> Courses { get; set; }

        public StudentResponseDTO(Student Student)
        {
            Id = Student.Id;
            FirstName = Student.FirstName;
            LastName = Student.LastName;
            Courses = new List<CourseDTO>();
            if (Student.CourseStudent != null)
            {
                foreach (var coursestudent in Student.CourseStudent)
                {
                    var courseDTO = new CourseDTO(coursestudent.Course);
                    Courses.Add(courseDTO);
                }
            }

        }

        public static List<StudentResponseDTO> FromRepository(IEnumerable<Student> Students)
        {
            var results = new List<StudentResponseDTO>();
            if (Students.Count() != 0)
            {
                foreach (var Student in Students)
                {
                    results.Add(new StudentResponseDTO(Student));
                }
            }
            return results;
        }


        public static StudentResponseDTO FromRepository(Student Student)
        {
            return new StudentResponseDTO(Student);
        }
    }
}