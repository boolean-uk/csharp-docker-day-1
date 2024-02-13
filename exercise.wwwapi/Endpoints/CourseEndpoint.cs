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
            students.MapPost("/", AddCourse);
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCourse(IRepository repository, CourseDto course)
        {
            if (!course.Title.Any()) return TypedResults.BadRequest();

            var result = await repository.AddCourse(new Course { Title = course.Title });
           Payload<Course> payload = new () { data = result };
            return TypedResults.Created($"{result.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CourseDto courseData)
        {
            if (!courseData.Title.Any()) return TypedResults.BadRequest();

            var course = await repository.GetCourse(id);
            if (course == null) return TypedResults.NotFound();

            course.Update(courseData);

            var result = await repository.UpdateCourse(course);
            Payload<Course> payload = new () { data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var course = await repository.GetCourse(id);
            if (course == null) return TypedResults.NotFound();

            await repository.DeleteCourse(course);

            Payload<Course> payload = new () { data = course };
            return TypedResults.Ok(payload);
        }
    }
}
