using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Courses;
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
            students.MapGet("/", GetCourses);
            students.MapGet("/{id}", GetCourse);
            students.MapPost("/", AddCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository, IMapper mapper)
        {
            Payload<IEnumerable<GetCourseDTO>> payload = new();
            try
            {
                var results = await repository.GetAll();
                payload.Data = results.Select(mapper.Map<GetCourseDTO>);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }

        }

        public static async Task<IResult> GetCourse(IRepository<Course> repository, IMapper mapper, int id)
        {
            Payload<GetCourseDTO> payload = new();
            try
            {
                Course course = await repository.Get(id);
                payload.Data = mapper.Map<GetCourseDTO>(course);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        public static async Task<IResult> AddCourse(IRepository<Course> repository, 
            IMapper mapper, 
            AddCourseDTO addCourseDTO)
        {
            Payload<GetCourseDTO> payload = new();
            try
            {
                Course course = new();
                course = mapper.Map<Course>(addCourseDTO);
                course = await repository.Add(course);
                payload.Data = mapper.Map<GetCourseDTO>(course);
                return TypedResults.Created(nameof(AddCourse), payload);
            } catch (Exception ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.BadRequest(payload);
            }
        }

        public static async Task<IResult> UpdateCourse(IRepository<Course> repository,
            IMapper mapper,
            [FromRoute] int id,
            [FromBody] AddCourseDTO addCourseDTO)
        {
            Payload<GetCourseDTO> payload = new();
            try
            {
                Course course = mapper.Map<Course>(addCourseDTO);
                course = await repository.Update(course, id);
                payload.Data = mapper.Map<GetCourseDTO>(course);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }

        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, IMapper mapper, int id)
        {
            Payload<GetCourseDTO> payload = new();
            try
            {
                Course course = await repository.Delete(id);
                payload.Data = mapper.Map<GetCourseDTO>(course);
                return TypedResults.Ok(payload);
            } catch (ArgumentException ex)
            {
                payload.Success = false;
                payload.Message = ex.Message;
                return TypedResults.NotFound(payload);
            }
        }
    }
}
