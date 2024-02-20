using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
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
            students.MapPost("/", CreateStudent);
            students.MapGet("/", GetStudents);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        public static async Task<IResult> CreateStudent(IRepository repository, StudentPost student)
        {
            var create = await repository.Create(student);
            if (create == null)
            {
                return TypedResults.BadRequest();
            }
            var payload = new Payload<Student>() { data = create };
            return TypedResults.Created($"Added student: ", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateStudent(IRepository repository, StudentPut student, int id)
        {
            var updated = await repository.Update(student, id);
            if (updated == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            var payload = new Payload<Student>() { data = updated };
            return TypedResults.Created($"updated student: ", payload);
        }

        private static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var delete = await repository.Delete(id);
            var payload = new Payload<Student>() { data = delete };
            return TypedResults.Ok(payload);
        }

    }
  
}
