using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
            students.MapPost("/Create", CreateStudent);
            students.MapPut("/Update{id}", UpdateStudent);
            students.MapDelete("/Delete{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<StudentPayload>>(results);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, InputStudentDTO data)
        {
            var result = await repository.AddStudent(data);
            var payload = new Payload<StudentPayload>(result);
            return TypedResults.Created($"http://localhost:5137/students/{payload.Data.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, InputStudentDTO data, int studentId)
        {
            var result = await repository.UpdateStudent(studentId, data);
            var payload = new Payload<StudentPayload>(result);
            return TypedResults.Created($"http://localhost:5137/students/{payload.Data.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int studentId)
        {
            var result = await repository.RemoveStudent(studentId);
            var payload = new Payload<StudentPayload>(result);
            return TypedResults.Ok(payload);
        }

    }
  

}
