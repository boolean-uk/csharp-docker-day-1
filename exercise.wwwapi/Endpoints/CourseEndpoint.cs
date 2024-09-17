using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;

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
            students.MapDelete("/{id:int}", DeleteCourse);
            students.MapPut("/{id:int}", UpdateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();
            var payload = new Payload<IEnumerable<Course>>() { Data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddCourse(IRepository repository, CoursePostModel model)
        {
            try
            {
                var result = await repository.AddCourse(new Course() { Title = model.Title, StartDate = model.StartDate, AvgGrade = model.AvgGrade});
                Payload<Course> payload = new Payload<Course>() { Data = result };
                return TypedResults.Ok(payload);
            }
            catch
            {
                return Results.BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository repository, int id)
        {
            try
            {
                var entity = await repository.GetACourse(id);
                if (await repository.DeleteCourse(id))
                {
                    return TypedResults.Ok(new { Title = entity.Title, StartDate = entity.StartDate });
                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCourse(IRepository repository, int id, CoursePostModel model)
        {
            try
            {
                var entity = await repository.GetACourse(id);
                if(entity == null) { return Results.NotFound(); }
                entity.Title = model.Title;
                entity.StartDate = model.StartDate;
                entity.AvgGrade = model.AvgGrade;

                var result = await repository.UpdateCourse(id, entity);
                return TypedResults.Ok(new { Title = entity.Title, StartDate = entity.StartDate, AvgGrade = entity.AvgGrade});
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
