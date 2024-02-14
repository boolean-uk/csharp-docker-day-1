using exercise.wwwapi.DataTransferObjects.Payload;
using exercise.wwwapi.Models.Models.Students;
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
            students.MapPost("/", PostStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{id}", GetAStudentById);
            students.MapPut("/{id}", PutStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }

        private static Task PostStudent(HttpContext context)
        {
            throw new NotImplementedException();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository<Student> repository)
        {
            var results = await repository.SelectAll();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }
        private static Task GetAStudentById(HttpContext context)
        {
            throw new NotImplementedException();
        }
        private static Task PutStudent(HttpContext context)
        {
            throw new NotImplementedException();
        }
        private static Task DeleteStudent(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }


}
