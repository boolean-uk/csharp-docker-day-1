using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
            students.MapGet("/{id}", GetCourseById);
            students.MapPost("/", CreateCourse);
            students.MapPut("/", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepositoryGeneric<Course> repository)
        {
            var results = await repository.GetAll();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(IRepositoryGeneric<Course> repository, int id)
        {
            var course = await repository.GetById(id);
            if (course == null)
            {
                return Results.NotFound();
            }
            var payload = new Payload<Course>() { data = course };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepositoryGeneric<Course> repository, Course course)
        {
            await repository.Add(course);
            var payload = new Payload<Course>() { data = course };
            return Results.Created($"/courses/{course.Id}", payload);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepositoryGeneric<Course> repository, Course course)
        {
           
            var updated = await repository.Update(course);
            if (updated != null)
            {
                var payload = new Payload<Course>() { data = updated };
                return TypedResults.Ok(payload);
            }
            else return TypedResults.BadRequest("Could not update, wrong input");

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepositoryGeneric<Course> repository, int id)
        {
            var deletedCourse = await repository.GetById(id);
            if (deletedCourse == null)
            {
                return Results.NotFound();
            }
            await repository.Delete(id);
            var payload = new Payload<Course>() { data = deletedCourse };
            return TypedResults.Ok(payload);
        }
    }
}
