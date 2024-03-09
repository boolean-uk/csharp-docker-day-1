using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.DTOs;

namespace exercise.wwwapi.Endpoints
{

    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var courses = app.MapGroup("courses");

            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetCourse);
            courses.MapPost("/", CreateCourse);
            courses.MapPut("/{id}", UpdateCourse);
            courses.MapDelete("/{id}", DeleteCourse);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository repository)
        {
            var results = await repository.GetCourses();

            var CourseDTO = new List<CourseResponseDTO>();

            foreach (Course s in results)
            {
                CourseDTO.Add(new CourseResponseDTO(s));
            }

            return TypedResults.Ok(CourseDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetCourse(int CourseId, IRepository repository)
        {

            Course? d = await repository.GetCourse(CourseId, PreloadPolicy.PreloadRelations);

            if (d == null)
            {
                return Results.NotFound("Course not found");
            }

            var CourseDTO = new CourseResponseDTO(d);

            return TypedResults.Ok(CourseDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteCourse(int CourseId, IRepository repository)
        {

            Course? d = await repository.DeleteCourse(CourseId, PreloadPolicy.PreloadRelations);

            if (d == null)
            {
                return Results.NotFound("Course not found");
            }

            var CourseDTO = new CourseResponseDTO(d);

            repository.SaveChanges();

            return TypedResults.Ok(CourseDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(CreateCoursePayload payload, IRepository repository)
        {

            if (payload.Title == null || payload.Teacher == null || payload.StartDate == null)
            {
                return Results.BadRequest("Non-empty fields required");
            }

            Course? d = await repository.CreateCourse(payload.Title, payload.Teacher, payload.StartDate);
            
            if (d == null)
            {
                return Results.BadRequest("Failed to create Course.");
            }

            repository.SaveChanges();

            return TypedResults.Ok(new CourseResponseDTO(d));
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCourse(int id, CourseUpdatePayload payload, IRepository repository)
        {

            var ogcust = repository.GetCourses().Result.FirstOrDefault(x => x.Id == id);

            if (ogcust == null)
            {
                return Results.BadRequest("The Course does not exist.");
            }

            if (payload.Title == "" && payload.Teacher == "" && payload.StartDate == null)
            {
                return Results.BadRequest("Non-empty fields are required");
            }


            Course? Course = await repository.UpdateCourse(id, payload.Title, payload.Teacher, payload.StartDate, PreloadPolicy.PreloadRelations);


            if (Course == null)
            {
                return Results.BadRequest("Failed to create Course.");
            }

            repository.SaveChanges();

            CourseResponseDTO cdto = new CourseResponseDTO(Course);

            return TypedResults.Created($"/courses{Course.Id}", cdto);
        }
    }
}
