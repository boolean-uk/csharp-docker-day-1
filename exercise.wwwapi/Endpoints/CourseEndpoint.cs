using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTO;
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
            var course = app.MapGroup("courses");
            course.MapGet("/", GetCourses);
            course.MapPost("/add", AddCourse);
            course.MapPut("/update/{id}", UpdateCourse);
            course.MapDelete("/delete/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> AddCourse(IRepository<Course> repository, CourseDTO inCourse)
        {
            Course course = new Course()
            {
                CourseName = inCourse.CourseName
            };

            var results = await repository.Insert(course);
            var payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CourseDTO inCourse)
        {
            var existingData = await repository.GetById(id);

            if (inCourse.CourseName != "string") existingData.CourseName = inCourse.CourseName;

            var results = await repository.Update(existingData);
            var payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var results = await repository.Delete(id);
            var payload = new Payload<Course>() { data = results };
            return TypedResults.Ok(payload);
        }
    }
}
