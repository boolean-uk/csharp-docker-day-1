using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.DTOs;

namespace exercise.wwwapi.Endpoints
{

    public static class CourseStudentEndpoint
    {
        public static void CourseStudentEndpointConfiguration(this WebApplication app)
        {
            var courseStudents = app.MapGroup("coursestudents");

            courseStudents.MapGet("/", GetCourseStudents);
            courseStudents.MapGet("/courses/{courseId}/students/{studentId}", GetCourseStudent);
            courseStudents.MapPost("/", CreateCourseStudent);
            courseStudents.MapDelete("/courses/{courseId}/students/{studentId}", DeleteCourseStudent);

        }

        /// APPOITMENTS 
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseStudents(IRepository repository)
        {
            var cs = await repository.GetCourseStudents();

            var courseStudentDTO = new List<CourseStudentDTO>();

            foreach (CourseStudent cost in cs)
            {
                courseStudentDTO.Add(new CourseStudentDTO(cost));
            }

            return TypedResults.Ok(courseStudentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourseStudent(IRepository repository, int courseId, int studentId)
        {
            CourseStudent? cs = await repository.GetCourseStudent(courseId, studentId, PreloadPolicy.PreloadRelations);

            if (cs == null)
            {
                return Results.NotFound("Course-student not found");
            }

            var CourseStudentDTO = new CourseStudentDTO(cs);

            return TypedResults.Ok(CourseStudentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteCourseStudent(int CourseId, int StudentId, IRepository repository)
        {

            CourseStudent? cs = await repository.DeleteCourseStudent(CourseId, StudentId, PreloadPolicy.PreloadRelations);

            if (cs == null)
            {
                return Results.NotFound("Course-student not found");
            }

            var CourseStudentDTO = new CourseStudentDTO(cs);

            repository.SaveChanges();

            return TypedResults.Ok(CourseStudentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourseStudent(CreateCourseStudentPayload payload, IRepository repository)
        {

            if (payload.courseId.GetType() != typeof(int) || payload.studentId.GetType() != typeof(int))
            {
                return Results.BadRequest("The id needs to be a number");
            }

            CourseStudent? cs = await repository.CreateCourseStudent(payload.courseId, payload.studentId);

            if (cs == null)
            {
                return Results.BadRequest("Failed to create appointment.");
            }

            repository.SaveChanges();

            return TypedResults.Ok(new CourseStudentDTO(cs));
        }




    }
}
