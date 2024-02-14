using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPost("/{studentId}/course/{courseId}", AddCourseToStudent);
        }

        private static async Task<IResult> AddCourseToStudent(IRepository<Student> repository, IRepository<Course> cRepository, int studentId, int courseId)
        {
            var student = await repository.GetById(studentId);
            if (student != null)
            {
                student.CourseId = courseId;
                var result = await repository.Update(student);
                return TypedResults.Ok(result);
            }
            return TypedResults.NotFound("");
            
        }

        public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
        {
            var result = await repository.GetById(id);
            var payload = new Payload<object> { data = new { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, DateOfBirth = result.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) } };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var result = await repository.Delete(id);
            var payload = new Payload<object> { data = new { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, DateOfBirth = result.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) } };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentPost student)
        {
            var s = new Student
            {
                Id = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await repository.Update(s);
            return TypedResults.Ok(new Payload<object> { data = new { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, DateOfBirth = result.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) } });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();
            var students = new List<object>();
            foreach (var student in results)
            {
                students.Add(new { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, DateOfBirth = student.DateOfBirth.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) });
            }
            var payload = new Payload<IEnumerable<object>>() { data = students };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, StudentPost student)
        {
            var s = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DOB,
                CreatedAt = DateTime.UtcNow,
            };
            var result = await repository.Insert(s);
            return TypedResults.Created("", new Payload<object> { data = new { Id = result.Id, FirstName = result.FirstName, LastName = result.LastName, DateOfBirth = student.DOB.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) } });
        }
  
    }
  

}
