using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/{id}", CreateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", UpdateStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            List<StudentCourseDTO> students = new List<StudentCourseDTO>();

            foreach (var student in results)
            {
                StudentCourseDTO studentDTO = new StudentCourseDTO()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    CourseTitle = student.Course.CourseTitle,
                    CourseStartDate = student.Course.CourseStartDate,
                    AverageGrade = student.Course.AverageGrade
                };
                students.Add(studentDTO);
            }
            var payload = new Payload<IEnumerable<StudentCourseDTO>>() { data = students };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, int id)
        {
            var student = await repository.GetStudent(id);
            StudentCourseDTO studentDTO = new StudentCourseDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseTitle = student.Course.CourseTitle,
                CourseStartDate = student.Course.CourseStartDate,
                AverageGrade = student.Course.AverageGrade
            };

            var payload = new Payload<StudentCourseDTO>() { data = studentDTO };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            await repository.CreateStudent(student);
            StudentDTO studentDTO = new StudentDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseId = student.CourseId
            };

            var payload = new Payload<StudentDTO>() { data = studentDTO };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var student = await repository.DeleteStudent(id);
            StudentDTO studentDTO = new StudentDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseId = student.CourseId
            };

            var payload = new Payload<StudentDTO>() { data = studentDTO };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, Student student)
        {
            await repository.UpdateStudent(id, student);
            StudentDTO studentDTO = new StudentDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseId = student.CourseId

            };

            var payload = new Payload<StudentDTO>() { data = studentDTO };
            return TypedResults.Ok(payload);
        }

    }
  

}
