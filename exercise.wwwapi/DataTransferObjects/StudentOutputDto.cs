using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentOutputDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public double AvgGrade { get; set; }
        public IEnumerable<object> Courses { get; set; }
        public static StudentOutputDto Create(Student student)
        {
            return new StudentOutputDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DOB = student.DOB,
                AvgGrade = student.AvgGrade,
                Courses = student.StudentCourses.Select(sc => new { sc.Course.Id, sc.Course.Name, sc.Course.Start }),
            };
        }
    }
}
