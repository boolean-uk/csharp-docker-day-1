using exercise.wwwapi.DataModels.StudentModels;

namespace exercise.wwwapi.Services
{
    public static class StudentDtoManager
    {
        public static Student Convert(InputStudent inputStudent)
        {
            return new Student
            {
                FirstName = inputStudent.FirstName,
                LastName = inputStudent.LastName,
                DateOfBirth = inputStudent.DateOfBirth,
                AverageGrade = inputStudent.AverageGrade,
                CourseId = inputStudent.CourseId
            };
        }

        public static OutputStudent Convert(Student student)
        {
            return new OutputStudent
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
                Course = CourseDtoManager.ConvertRemoveStudents(student.Course)
            };
        }

        public static IEnumerable<OutputStudent> Convert(IEnumerable<Student> students)
        {
            return students.Select(Convert);
        }
    }
}
