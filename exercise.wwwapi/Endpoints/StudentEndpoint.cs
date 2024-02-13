using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.StudentDTOs;
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
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<GetStudentDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentById(int id, IRepository repository)
        {
            var results = await repository.GetStudentById(id);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Student with id {id} not found." });
            var payload = new Payload<GetStudentDTO>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(CreateStudentDTO cDTO, IRepository repository)
        {
            var results = await repository.CreateStudent(cDTO);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Course with id {cDTO.CourseId} not found." });
            var payload = new Payload<GetStudentDTO>() { data = results };
            return TypedResults.Created(" ", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(int id, UpdateStudentDTO uDTO, IRepository repository)
        {
            var results = await repository.UpdateStudent(id, uDTO);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Student with id {id} not found." });
            var payload = new Payload<GetStudentDTO>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(int id, IRepository repository)
        {
            var results = await repository.DeleteStudent(id);
            if (results == null) return TypedResults.NotFound(new Payload<string>() { data = $"Student with id {id} not found." });
            var payload = new Payload<GetStudentDTO>() { data = results };
            return TypedResults.Ok(payload);
        }

    }


}
