using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Extensions;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModels;
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
            students.MapGet("/{id}", GetACourse);
            students.MapPost("/", CreateCourse);
            students.MapPut("/", UpdateCourse);
            students.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            if (!results.Any()) return TypedResults.NotFound("No courses found");
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetACourse(IRepository repository, int id)
        {
            var result = await repository.GetACourse(id);
            if (result is null) return TypedResults.NotFound("That course was not found");

            var payload = new Payload<Course>() { data = result };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, CoursePost coursePost)
        {
            var course = coursePost.ToCourse();
            var results = await repository.CreateCourse(course);

            var payload = new Payload<CourseDTO> { data = results.ToDTO() };

            return TypedResults.Created("", payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository repository, CourseUpdate courseUpdate, int id)
        {
            var course = await repository.GetACourse(id);
            if (course is null) return TypedResults.NotFound("Didn't find that course by id");
            course.Update(courseUpdate);
            Course result = await repository.UpdateCourse(course);

            var payload = new Payload<CourseDTO> { data = result.ToDTO() };
            return TypedResults.Created("", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            Course course = await repository.GetACourse(id);
            if (course is null) return TypedResults.NotFound("Didn't find that course by id");

            course = await repository.DeleteCourse(course);

            var payload = new Payload<CourseDTO> {data = course.ToDTO() };

            return TypedResults.Ok(payload);
        }
    }
}
