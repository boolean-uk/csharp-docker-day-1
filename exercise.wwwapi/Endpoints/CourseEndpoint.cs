
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            app.MapPost("/courses", AddCourse);
            app.MapGet("/courses", GetCourses);
            app.MapGet("/courses/{id}", GetCourseById);
            app.MapPut("/courses/{id}", UpdateCourse);
            app.MapDelete("/courses/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            var results = await repository.Get();
            if (results is null || !results.Any()) return TypedResults.NotFound("No courses found.");
            var payload = new Payload<IEnumerable<Course>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetCourseById(IRepository<Course> repository, int id)
        {
            var result = await repository.GetById(id);
            if (result is null) return TypedResults.NotFound($"Course with ID {id} not found.");
            var payload = new Payload<Course>() { data = result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourse(IRepository<Course> repository, CourseDto courseDto)
        {
            var course = new Course
            {
                // Assume CourseDto has similar fields to Course; map as necessary
                Name = courseDto.Name,
                Start = courseDto.Start
            };
            await repository.Insert(course);
            return TypedResults.Created($"/courses/{course.Id}", course);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CourseDto courseDto)
        {
            var course = await repository.GetById(id);
            course.Start = courseDto.Start;
            course.Name = courseDto.Name;
            var updateResult = await repository.Update(course);
            if (updateResult == null) return TypedResults.NotFound($"Course with ID {id} not found.");
            return TypedResults.Ok(new Payload<Course>() { data=updateResult});
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var deleteResult = await repository.Delete(id);
            if (deleteResult==null) return TypedResults.NotFound($"Course with ID {id} not found.");
            return TypedResults.Ok(new Payload<Course>() { data=deleteResult});
        }
    }
}
