using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

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
            courses.MapPost("/", AddCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            return TypedResults.Ok(CourseDTO.FromRepository(results));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourse(IRepository repository, Course course)
        {
            var addedCourse = await repository.AddCourse(course);
            return TypedResults.Created("Created", new CourseDTO(addedCourse));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, Course course)
        {
            var updatedCourse = await repository.UpdateCourse(id, course);
            return TypedResults.Ok(new CourseDTO(updatedCourse));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            await repository.DeleteCourse(id);
            return TypedResults.NoContent();
        }
    }
}
