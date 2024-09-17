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
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        //fixa resten

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            try
            {
                var results = await repository.DeleteObject(id);
                var payload = new Payload<Student>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, string FirstName, string LastName, DateTime DoB)
        {
            try
            {
                var results = await repository.UpdateObject(id, FirstName, LastName, DoB);
                var payload = new Payload<Student>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> CreateStudent(IRepository<Student> repository, string FirstName, string LastName, DateTime DoB)
        {
            try
            {
                var results = await repository.CreateObject(FirstName, LastName, DoB);
                var payload = new Payload<Student>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> GetStudent(IRepository<Student> repository, IFilter<Student> filter, int id)
        {
            try
            {
                var results = repository.GetObject(filter, id);
                var payload = new Payload<Student>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return payload.Data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            try
            {
                var results = await repository.GetObjects();
                var payload = new Payload<IEnumerable<Student>>() { Data = results };
                payload.status = payload.Data != null ? "Success" : "Failure";
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
    }
}
