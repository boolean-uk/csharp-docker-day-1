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
            students.MapGet("/student/:{id}", GetStudent);
            students.MapPost("/createstudent", CreateStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, int id)
        {
            var result = await repository.GetStudent(id);
            return TypedResults.Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentDTO student)
        {
            var result = await repository.CreateStudent(student);
            return TypedResults.Ok(result);
        }
    }
  

}
