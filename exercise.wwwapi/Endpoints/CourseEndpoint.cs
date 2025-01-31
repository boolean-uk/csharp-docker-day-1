using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
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
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            return TypedResults.Ok(new Payload<IEnumerable<Course>> { Data = results });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseById(IRepository repository, int id)
        {
            var result = await repository.GetCourseById(id);
            if (result != null)
            {
                return TypedResults.Ok(new Payload<Course> { Data = result });
            }
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository repository, CourseDTO courseDTO)
        {
            var course = new Course
            {
                Title = courseDTO.Title,
                Description = courseDTO.Description
            };
            await repository.AddCourse(course);
            return TypedResults.Created($"/courses/{course.Id}", course);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CourseDTO courseDTO)
        {
            var existingCourse = await repository.GetCourseById(id);

            if (existingCourse == null)
            {
                return TypedResults.NotFound();
            }
            existingCourse.Title = courseDTO.Title;
            existingCourse.Description = courseDTO.Description;

            var updatedCourse = await repository.UpdateCourse(id, existingCourse);

            return TypedResults.Created($"/courses/{id}", updatedCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            var course = await repository.GetCourseById(id);
            if (course == null)
            {
                return TypedResults.NotFound();
            }

            await repository.DeleteCourse(id);
            return TypedResults.Ok(course);
        }
    }
}
