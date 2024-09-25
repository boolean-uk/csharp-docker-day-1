using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTOs;
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
            courses.MapPost("/", AddCourse);
            courses.MapPatch("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository, IMapper mapper)
        {
            var results = await repository.GetCourses();
            var courseDtos = mapper.Map<IEnumerable<GetCourseDTO>>(results);

            var payload = new Payload<IEnumerable<GetCourseDTO>>() { Data = courseDtos };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourse(IRepository repository, IMapper mapper, PostCourseDTO courseDTO)
        {
            Course course = mapper.Map<Course>(courseDTO);
            var createdCourse = await repository.AddCourse(course);
            var getCourseDTO = mapper.Map<GetCourseDTO>(createdCourse);
            var location = $"/courses/{createdCourse.Id}";

            var payload = new Payload<GetCourseDTO>() { Data = getCourseDTO };

            return TypedResults.Created(location, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository repository, IMapper mapper, PatchCourseDTO courseDTO, int id)
        {

            Course updatedCourse = null;
            try
            {
                updatedCourse = await repository.UpdateCourse(courseDTO, id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var getCourseDTO = mapper.Map<GetCourseDTO>(updatedCourse);
            var location = $"/courses/{updatedCourse.Id}";

            var payload = new Payload<GetCourseDTO>
            {
                Data = getCourseDTO
            };

            return TypedResults.Created(location, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository repository, IMapper mapper, int id)
        {
            Course deletedCourse = null;

            try
            {
                deletedCourse = await repository.DeleteCourse(id);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

            var getCourseDTO = mapper.Map<GetCourseDTO>(deletedCourse);

            var payload = new Payload<GetCourseDTO>
            {
                Data = getCourseDTO
            };

            return TypedResults.Ok(payload);
        }
    }
}
