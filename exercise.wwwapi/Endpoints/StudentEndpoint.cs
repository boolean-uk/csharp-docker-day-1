using exercise.wwwapi.DataModels.StudentModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Services;
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
            students.MapGet("/", GetAll);
            students.MapGet("/{id}", Get);
            students.MapPost("/", Create);
            students.MapPut("/{id}", Update);
            students.MapDelete("/{id}", Delete);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Student> repository)
        {
            var results = await repository.Get();

            IEnumerable<OutputStudent> outputStudent = StudentDtoManager.Convert(results);

            var payload = new Payload<IEnumerable<OutputStudent>>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Student> repository, int id)
        {
            var result = await repository.Get(id);
            if (result == null)
                return TypedResults.NotFound();

            OutputStudent outputStudent = StudentDtoManager.Convert(result);

            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Student> repository, InputStudent student)
        {
            Student newStudent = StudentDtoManager.Convert(student);

            var result = await repository.Create(newStudent);

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<Student> repository, int id, Student student)
        {
            var result = await repository.Update(student);

            if (result == null)
                return TypedResults.NotFound();

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Student> repository, int id)
        {
            var result = await repository.Delete(id);
            if (result == null)
                return TypedResults.NotFound();

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }
    }
}
