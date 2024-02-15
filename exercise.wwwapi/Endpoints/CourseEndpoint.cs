using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Request;
using exercise.wwwapi.DataTransferObjects.Response;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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
            courses.MapGet("/", GetAll);
            courses.MapGet("/{id}", GetById);
            courses.MapPut("/{id}", UpdateById);
            courses.MapPost("/", Create);
            courses.MapDelete("/{id}", DeleteById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAll(IRepository<Course> repository)
        {
            var courses = await repository.GetAll();
            List<CourseResponseDTO> response = new List<CourseResponseDTO>();
            foreach (Course course in courses)
            {
                response.Add(new CourseResponseDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    StartDate = course.StartDate
                });
            }
            return TypedResults.Ok(new Payload<List<CourseResponseDTO>>() {data = response});
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetById(IRepository<Course> repository, int id)
        {
            Course? course = await repository.GetById(id);
            if (course == null) return TypedResults.NotFound($"No course with id={id}");
            CourseResponseDTO response = new CourseResponseDTO()
            {
                Id = course.Id,
                Title = course.Title,
                StartDate = course.StartDate
            };
            return TypedResults.Ok(new Payload<CourseResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> DeleteById(IRepository<Course> repository, int id)
        {
            Course? course = await repository.DeleteById(id);
            if (course == null) return TypedResults.NotFound($"No course with id={id}");
            CourseResponseDTO response = new CourseResponseDTO()
            {
                Id = course.Id,
                Title = course.Title,
                StartDate = course.StartDate
            };
            return TypedResults.Ok(new Payload<CourseResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static async Task<IResult> UpdateById(IRepository<Course> repository, int id, CourseRequestDTO request)
        {
            Course? course = await repository.GetById(id);
            if (course == null) return TypedResults.NotFound($"No course with id={id}");
            course.Title = request.CourseTitle;
            course.StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
            course = await repository.Update(course);
            CourseResponseDTO response = new CourseResponseDTO()
            {
                Id = course.Id,
                Title = course.Title,
                StartDate = course.StartDate
            };
            return TypedResults.Created($"/{course.Id}", new Payload<CourseResponseDTO>() { data = response });
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> Create(IRepository<Course> courseRepository, CourseRequestDTO request)
        {
            Course newCourse = await courseRepository.Insert(new Course()
            {
                Title = request.CourseTitle,
                StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc)
            });
            CourseResponseDTO response = new CourseResponseDTO()
            {
                Id = newCourse.Id,
                Title = newCourse.Title,
                StartDate = newCourse.StartDate
            };
            return TypedResults.Created($"/{newCourse.Id}", new Payload<CourseResponseDTO>() { data = response });
        }


    }
}
