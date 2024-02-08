using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using static exercise.wwwapi.DataTransferObjects.Payload;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            return TypedResults.Ok(results);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, int studentId)
        {
            var result = await repository.GetStudent(studentId);
            if(result == null) { return TypedResults.BadRequest(); }
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> CreateStudent(IRepository repository, CreateStudentPayload payload)
        {
            Student student = new Student { FirstName = payload.FirstName, LastName = payload.LastName, DateOfBirth = payload.DateOfBirth, CourseTitle = payload.CourseTitle, Grade = payload.Grade,StartDate = payload.StartDate};
            var result = await repository.CreateStudent(student);
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> DeleteStudent(IRepository repository, int studentId)
        {
            Student? student = await repository.GetStudent(studentId);
            if (student == null) { return TypedResults.BadRequest(); }
            var result = await repository.DeleteStudent(studentId);
            if (result == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> UpdateStudent(IRepository repository, int studentId, UpdateStudentPayload payload)
        {
            Student? studentToUpdate = await repository.GetStudent(studentId);
            if (studentToUpdate == null) { return TypedResults.BadRequest(); }
            Student newInfo = new Student { FirstName = payload.FirstName, LastName = payload.LastName, DateOfBirth = payload.DateOfBirth, CourseTitle = payload.CourseTitle, Grade = payload.Grade, StartDate = payload.StartDate };
            var result = await repository.UpdateStudent(studentId, newInfo);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }
    }
  

}
