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
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapGet("/{id}/courses", GetCoursesByStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = StudentDTO.FromStudents(results);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(int id, IRepository repository)
        {
            var result = await repository.GetStudent(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new StudentDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(CreateStudentPayload payload, IRepository repository)
        {
            var result = await repository.CreateStudent(payload);
            return TypedResults.Ok(new StudentDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(int id, UpdateStudentPayload payload, IRepository repository)
        {
            var result = await repository.UpdateStudent(id, payload);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(new StudentDTO(result));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(int id, IRepository repository)
        {
            var result = await repository.GetStudent(id);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            await repository.DeleteStudent(id);
            return TypedResults.NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCoursesByStudent(int id, IRepository repository)
        {
            var results = await repository.GetCoursesByStudent(id);
            return TypedResults.Ok(CourseDTO.FromCourses(results));
        }



    }
  

}
