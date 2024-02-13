using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.PostModels;
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
            courses.MapPut("/{id}", EditCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.GetCourses();
            ICollection<object> dtObjects = new List<object>();
            foreach(var item in results)
            {
                dtObjects.Add(item.DtCourse());
            }
            var payload = new Payload<IEnumerable<object>>() { data = dtObjects };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(IRepository<Course> repository, int id)
        {
            var results = await repository.GetById(id);
            var payload = new Payload<object>() { data = results.DtCourse() };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, PostCourse model)
        {
            Course results = await repository.Insert(new Course { Title = model.Title});
            var payload = new Payload<object>() { data = results.DtCourse() };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> EditCourse(IRepository<Course> repository, PostCourse model, int id)
        {
            var results = await repository.Update(new Course { Id=id, Title = model.Title });
            var payload = new Payload<object>() { data = results.DtCourse() };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var results = await repository.Delete(id);
            var payload = new Payload<object>() { data = results.DtCourse() };
            return TypedResults.Ok(payload);
        }

    }
}
