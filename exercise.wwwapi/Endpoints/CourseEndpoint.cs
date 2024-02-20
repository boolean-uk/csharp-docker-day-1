using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");
            courses.MapPost("/", CreateCourse);
            courses.MapGet("/", GetCourses);
            courses.MapPut("/", UpdateCourse);
            courses.MapDelete("/", DeleteCourse);
        }

        public static async Task<IResult> CreateCourse(IRepository repository, CoursePost course)
        {
            var create = await repository.CreateCourse(course);
            if (create == null)
            {
                return TypedResults.BadRequest();
            }
            var payload = new Payload<Course>() { data = create };
            return TypedResults.Created($"Added course: ", payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateCourse(IRepository repository, CoursePut course, int id)
        {
            var updated = await repository.UpdateCourse(course, id);
            if (updated == null)
            {
                return Results.NotFound($"Id: {id} not found!");
            }
            var payload = new Payload<Course>() { data = updated };
            return TypedResults.Created($"updated course: ", payload);
        }

        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var delete = await repository.DeleteCourse(id);
            var payload = new Payload<Course>() { data = delete };
            return TypedResults.Ok(payload);
        }

    }
}
