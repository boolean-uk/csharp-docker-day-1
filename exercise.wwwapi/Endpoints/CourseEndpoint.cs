using exercise.wwwapi.DataTransferObjects.Payload;
using exercise.wwwapi.Helpers;
using exercise.wwwapi.Models.Interfaces;
using exercise.wwwapi.Models.Models.Courses;
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
            students.MapPost("/", PostCourse);
            students.MapGet("/", GetAllCourses);
            students.MapGet("/{id}", GetACourseById);
            students.MapPut("/{id}", PutCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        private static async Task<IResult> PostCourse(IRepository<Course> repository, CoursePost model)
        {
            var payload = new Payload<ICourse>() 
            { 
                status = DTOHelper.PropertyChecker<CoursePost>(model, "POST"),
                data = model 
            };

            if(payload.status != "success")
            {
                return TypedResults.BadRequest(payload);
            }

            var newInsert = await repository.Insert(DTOHelper.EntityMapper<Course>(model));
            var courseLite = DTOHelper.EntityMapper<CourseLiteDTO>(newInsert);
            payload.data = DTOHelper.EntityMapper<CourseLiteDTO>(courseLite);

            return TypedResults.Created($"/{courseLite.Id}", newInsert);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllCourses(IRepository<Course> repository)
        {
            var results = await repository.SelectAll();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }
        private static Task GetACourseById(HttpContext context)
        {
            throw new NotImplementedException();
        }
        private static Task PutCourse(HttpContext context)
        {
            throw new NotImplementedException();
        }
        private static Task DeleteCourse(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
