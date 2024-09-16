using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.ViewModels;

namespace exercise.wwwapi.Extensions
{
    public static class StudentExtensions
    {
        public static StudentDTO ToDTO(this Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth.ToString("yyyy-MM-dd"),
                Course = student.Course.Title,
                AverageGrade = student.AverageGrade
            };
        }
        public static StudentDTO ToDTO(this Student student, Course course)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth.ToString("yyyy-MM-dd"),
                Course = course.Title,
                AverageGrade = student.AverageGrade
            };
        }
        public static void Update(this Student student, StudentUpdate studentUpdate)
        {
            if (!string.IsNullOrEmpty(studentUpdate.FirstName)) student.FirstName = studentUpdate.FirstName;
            if (!string.IsNullOrEmpty(studentUpdate.LastName)) student.LastName = studentUpdate.LastName;
            if (!string.IsNullOrEmpty(studentUpdate.DateOfBirth)) student.DateOfBirth = DateTime.Parse(studentUpdate.DateOfBirth).ToUniversalTime();
            student.CourseId = studentUpdate.CourseId;
            student.AverageGrade = studentUpdate.AverageGrade;
        }
        public static Student ToStudent(this StudentPost studentPost)
        {
            return new Student
            {
                FirstName = studentPost.FirstName,
                LastName = studentPost.LastName,
                DateOfBirth = DateTime.Parse(studentPost.DateOfBirth).ToUniversalTime(),
                CourseId = studentPost.CourseId,
                AverageGrade = studentPost.AverageGrade
            };
        }
    }
}