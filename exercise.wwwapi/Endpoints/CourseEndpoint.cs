using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");
            courses.MapGet("/" , GetCourses);
            courses.MapGet("/{id}" , GetCourse);
            courses.MapPost("/" , CreateCourse);
            courses.MapPut("/{id}" , UpdateCourse);
            courses.MapDelete("/{id}" , DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(ICourseRepository repository)
        {
            var courses = await repository.GetCoursesAsync();
            var courseDtos = courses.Select(c => new CourseDto
            {
                Id = c.Id ,
                Title = c.Title
            });
            var payload = new Payload<IEnumerable<CourseDto>>() { data = courseDtos };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourse(Guid id , ICourseRepository repository)
        {
            var course = await repository.GetCourseAsync(id);
            if(course == null)
            {
                return TypedResults.NotFound();
            }
            var courseDto = new CourseDto
            {
                Id = course.Id ,
                Title = course.Title
            };
            var payload = new Payload<CourseDto>() { data = courseDto };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourse([FromBody] CourseDto courseDto , [FromServices] ICourseRepository repository)
        {
            var course = new Course
            {
                Id = courseDto.Id ,
                Title = courseDto.Title
            };
            var createdCourse = await repository.AddCourseAsync(course);
            var createdCourseDto = new CourseDto
            {
                Id = createdCourse.Id ,
                Title = createdCourse.Title
            };
            return Results.Created($"/courses/{createdCourseDto.Id}" , createdCourseDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateCourse(Guid id , CourseDto courseDto , ICourseRepository repository)
        {
            if(id != courseDto.Id)
            {
                return TypedResults.BadRequest();
            }
            var course = new Course
            {
                Id = courseDto.Id ,
                Title = courseDto.Title
            };
            var updatedCourse = await repository.UpdateCourseAsync(course);
            var updatedCourseDto = new CourseDto
            {
                Id = updatedCourse.Id ,
                Title = updatedCourse.Title
            };
            var payload = new Payload<CourseDto>() { data = updatedCourseDto };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> DeleteCourse(Guid id , ICourseRepository repository)
        {
            await repository.DeleteCourseAsync(id);
            return TypedResults.NoContent();
        }
    }
}
