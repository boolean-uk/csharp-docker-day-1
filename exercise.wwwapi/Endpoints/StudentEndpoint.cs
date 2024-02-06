using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
  public class UserPayload
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? CourseName { get; set; }
            public DateTime? StartDateOfCourse { get; set; }
            public float? AvarageGrade { get; set; }

            // Method to check if all properties are filled
            public bool AreAllPropertiesFilled()
            {
                return FirstName != null && LastName != null && DateOfBirth != null &&
                       CourseName != null && StartDateOfCourse != null && AvarageGrade != null;
            }
        }

public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetStudents);
            students.MapGet("/{id:int}", GetStudentById);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id:int}", UpdateStudentById);
            students.MapDelete("/{id:int}", DeleteStudentById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            if (results is null || !results.Any()) return TypedResults.NotFound("No students found.");
            return TypedResults.Ok(results);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var student = await repository.GetStudentById(id);
            return student != null ? TypedResults.Ok(student) : TypedResults.NotFound($"Student with ID {id} not found.");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, UserPayload payload)
        {
            if (!payload.AreAllPropertiesFilled())
            {
                return TypedResults.BadRequest("All fields are required.");
            }

            var student = new Student
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateOfBirth = payload.DateOfBirth.Value, 
                CourseName = payload.CourseName,
                StartDateOfCourse = payload.StartDateOfCourse.Value, 
                AvarageGrade = payload.AvarageGrade.Value 
            };

            var createdStudent = await repository.CreateStudent(student);
            return TypedResults.Created($"/students/{createdStudent.Id}", createdStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudentById(IRepository repository, int id, UserPayload payload)
        {
            var existingStudent = await repository.GetStudentById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound($"Student with ID {id} not found.");
            }

            if (payload.FirstName != null) existingStudent.FirstName = payload.FirstName;
            if (payload.LastName != null) existingStudent.LastName = payload.LastName;
            if (payload.DateOfBirth.HasValue) existingStudent.DateOfBirth = payload.DateOfBirth.Value;
            if (payload.CourseName != null) existingStudent.CourseName = payload.CourseName;
            if (payload.StartDateOfCourse.HasValue) existingStudent.StartDateOfCourse = payload.StartDateOfCourse.Value;
            if (payload.AvarageGrade.HasValue) existingStudent.AvarageGrade = payload.AvarageGrade.Value;

            await repository.UpdateStudentById(id, existingStudent);

            return TypedResults.Ok(existingStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudentById(IRepository repository, int id)
        {
            var deletedStudent = await repository.DeleteStudentById(id);
            return deletedStudent != null ? TypedResults.Ok(deletedStudent) : TypedResults.NotFound($"Student with ID {id} not found.");
        }

    }
  

}
