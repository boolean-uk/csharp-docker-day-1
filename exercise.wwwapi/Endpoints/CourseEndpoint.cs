using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");

            courses.MapPost("/", CreateCourse);
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourseById);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        public static async Task<IResult> CreateCourse(IRepository<Course> repository, IMapper mapper, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return TypedResults.BadRequest("Course name is invalid.");
            }

            var newCourse = new Course { Name = name };
            var createdCourse = await repository.Insert(newCourse);
            var courseDTO = mapper.Map<CourseDTO>(createdCourse);
            var payload = new Payload<CourseDTO>() { Data = courseDTO };
            return TypedResults.Created($"/courses/{createdCourse.Id}", payload);
        }

        public static async Task<IResult> GetCourses(IRepository<Course> repository, IMapper mapper)
        {
            var results = await repository.Get();
            var courseDTOs = results.Select(course => mapper.Map<CourseDTO>(course));
            var payload = new Payload<IEnumerable<CourseDTO>>() { Data = courseDTOs };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> GetCourseById(IRepository<Course> repository, IMapper mapper, int id)
        {
            var course = await repository.GetById(id);
            if (course == null)
            {
                return TypedResults.NotFound();
            }

            var courseDTO = mapper.Map<CourseDTO>(course);
            var payload = new Payload<CourseDTO>() { Data = courseDTO };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, IMapper mapper, int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return TypedResults.BadRequest("Course name is invalid.");
            }

            var existingCourse = await repository.GetById(id);
            if (existingCourse == null)
            {
                return TypedResults.NotFound();
            }

            existingCourse.Name = name;
            var updatedCourse = await repository.Update(existingCourse);
            var courseDTO = mapper.Map<CourseDTO>(updatedCourse);
            var payload = new Payload<CourseDTO>() { Data = courseDTO };
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, IMapper mapper, int id)
        {
            var existingCourse = await repository.GetById(id);
            if (existingCourse == null)
            {
                return TypedResults.NotFound();
            }

            var deletedCourse = await repository.Delete(id);
            var courseDTO = mapper.Map<CourseDTO>(deletedCourse);
            var payload = new Payload<CourseDTO>() { Data = courseDTO };
            return TypedResults.Ok(payload);
        }
    }
}
