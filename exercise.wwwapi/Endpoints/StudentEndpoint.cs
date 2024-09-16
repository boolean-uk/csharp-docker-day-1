using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Extensions;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
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
            students.MapGet("/{id}", GetAStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            Student student = await repository.GetAStudent(id);
            if (student is null) return TypedResults.NotFound("Student not found");

            Student result = await repository.DeleteStudent(student);

            var payload = new Payload<StudentDTO> { data = result.ToDTO() };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentUpdate studentUpdate, int id)
        {
            Student student = await repository.GetAStudent(id);
            if (student is null) return TypedResults.NotFound("Student not found");

            student.Update(studentUpdate);
            Student result = await repository.UpdateStudent(student);

            var payload = new Payload<StudentDTO> { data = result.ToDTO() };
            return TypedResults.Created("", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPost studentPost)
        {
            var course = await repository.GetACourse(studentPost.CourseId);
            if (course is null) return TypedResults.NotFound("That course was not found");

            var student = studentPost.ToStudent();
            Student result = await repository.CreateStudent(student);
            var payload = new Payload<StudentDTO> { data = result.ToDTO() };

            return TypedResults.Created("", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAStudent(IRepository repository, int id)
        {
            Student student = await repository.GetAStudent(id);
            if (student is null) return TypedResults.NotFound("Student not found");

            var payload = new Payload<StudentDTO> { data = student.ToDTO() };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            if (!results.Any()) return TypedResults.NotFound("Found no students");
            List<StudentDTO> students = (from student in results select student.ToDTO()).ToList();
            var payload = new Payload<IEnumerable<StudentDTO>>() { data = students };
            return TypedResults.Ok(payload);
        }

    }
  

}
