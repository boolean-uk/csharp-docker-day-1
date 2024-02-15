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
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
        {
            Course course = await repository.Get(id);
            if (course == null) return TypedResults.NotFound("course not found");
            Payload<Course> payload = new Payload<Course> { data = course };

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, Course course)
        {
            if (course == null) return TypedResults.BadRequest("Course missing values");
            course = await repository.Create(course);
            Payload<Course> payload = new Payload<Course> { data = course };

            return TypedResults.Created($"courses/{course.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, Course courseDto, int id)
        {
            Course course = await repository.Get(id);
            if (course == null) return TypedResults.NotFound("Course not found");

            course.CourseStartDate = courseDto.CourseStartDate;
            course.CourseTitle = courseDto.CourseTitle;
            course.AverageGrade = courseDto.AverageGrade;

            course = await repository.Update(course);

            Payload<Course> payload = new Payload<Course> { data = course };

            return TypedResults.Created($"courses/{course.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            Course course = await repository.Get(id);
            if (course == null) return TypedResults.NotFound("Course not found");

            course = await repository.Delete(course);
            Payload<Course> payload = new Payload<Course> { data = course };

            return TypedResults.Ok(payload);
        }

    }
}
