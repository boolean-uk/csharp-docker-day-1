using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Course;
using exercise.wwwapi.DataTransferObjects.Student;
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
            students.MapPost("/", CreateCourse);
            students.MapPut("/{id}", UpdateCourse);
            students.MapDelete("/{id}", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository, IMapper mapper)
        {
            var source = await repository.GetAll();
            //Trannsferring:
            List<OutCourseDTO> results = source.Select(mapper.Map<OutCourseDTO>).ToList();

            var payload = new Payload<List<OutCourseDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }

    


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, IMapper mapper, [FromBody] InCourseDTO newCourse)
        {
            Payload<OutCourseDTO> response = new();

            try
            {
                Course course = mapper.Map<Course>(newCourse);

                // source: 
                var source = await repository.Add(course);
                //Transferring:
                response.data = mapper.Map<OutCourseDTO>(source);
                return TypedResults.Created(nameof(CreateCourse), response);
            }

            catch (Exception ex)
            {
                return TypedResults.BadRequest(response);
            }


        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, IMapper mapper, [FromBody] InCourseDTO newCourse, [FromQuery] int id)
        {

            Payload<OutCourseDTO> response = new();

            try
            {
                Course course = mapper.Map<Course>(newCourse);
                course.Id = id;
                // source: 
                var source = await repository.UpdateById(course, id);
                //Transferring:

                response.data = mapper.Map<OutCourseDTO>(source);
                return TypedResults.Ok(response);
            }

            catch (Exception ex)
            {
                return TypedResults.NotFound(response);
            }

        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, IMapper mapper, [FromQuery] int id)
        {

            Payload<OutCourseDTO> response = new();

            try
            {
                // source: 
                var source = await repository.DeleteCourseById(id);
                //Transferring:
                response.data = mapper.Map<OutCourseDTO>(source);
                return TypedResults.Ok(response);
            }

            catch (Exception ex)
            {
                return TypedResults.NotFound(response);
            }

        }

    }
}

