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
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCourse(IRepository repository, Course course)
        {
            var createdCourse = await repository.CreateCourse(course);

            if (createdCourse != null)
            {
                var payload = new Payload<Course>() { data = createdCourse };
                return TypedResults.Ok(payload);
            }
            else
            {
                return TypedResults.BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, Course updatedCourse)
        {
            var result = await repository.UpdateCourse(id, updatedCourse);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            var payload = new Payload<Course>() { data = result };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var deletedCourse = await repository.DeleteCourse(id);
            var payload = new Payload<Course>() { data = deletedCourse };

            return TypedResults.Ok(payload);
        }
    }
}
