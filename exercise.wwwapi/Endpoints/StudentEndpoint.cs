using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{Id}", UpdateStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            Student createdStudent = await repository.AddStudent(student);
            Payload<Student> payload = new Payload<Student>() { Data = createdStudent };
            return TypedResults.Created("", payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, Student student)
        {
            Student studentUpdated = await repository.UpdateStudent(id, student);
            Payload<Student> payload = new Payload<Student>() { Data = studentUpdated };
            return TypedResults.Created("", payload);
        }
    }


}
