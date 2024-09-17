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
            students.MapPost("/", CreateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", UpdateStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository repository, int id)
        {
            var results = await repository.GetStudent(id);
            return results != null ? TypedResults.Ok(new Payload<Student>() { Data = results }) : TypedResults.NotFound(new Payload<string>() { Data = "No student found" });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            Student results = await repository.CreateStudent(student);
            return TypedResults.Created("/", new Payload<Student>() { Data = results });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            Student results = await repository.DeleteStudent(id);
            return results != null ? TypedResults.Ok(new Payload<Student>() { Data = results }) : TypedResults.NotFound(new Payload<string>() { Data = "No student found" });

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, Student student)
        {
            Student results = await repository.UpdateStudent(student, id);
            return results != null ? TypedResults.Created("/", new Payload<Student>() { Data = results }) : TypedResults.NotFound(new Payload<string>() { Data = "No student found" });
        }
    }
}
