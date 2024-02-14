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
            var courses = app.MapGroup("courses");

            courses.MapGet("", GetCourses);
            courses.MapGet("{id}", GetCourseByID);
            courses.MapPut("{id}", UpdateCourse);
            courses.MapPost("", CreateCourse);
            courses.MapDelete("{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetAll();
            Payload<IEnumerable<Course>> payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseByID(IRepository<Course> repository, int id)
        {
            var results = await repository.GetByID(id);
            Payload<Course> payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, Course newEntity)
        {
            var results = await repository.Insert(newEntity);
            Payload<Course> payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, Course updatedCourse)
        {
            var results = await repository.Update(id, updatedCourse);
            Payload<Course> payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            Payload<Course> payload = new Payload<Course>() { data = await repository.Delete(id) };
            return TypedResults.Ok(payload);
        }
    }
}
