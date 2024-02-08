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
            public int? CourseId { get; set; }
            public float? AvarageGrade { get; set; }

            // Method to check if all properties are filled
            public bool AreAllPropertiesFilled()
            {
                return FirstName != null && LastName != null && DateOfBirth != null &&
                       CourseId != null && AvarageGrade != null;
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
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var students = await repository.GetStudents();
            if (students is null || !students.Any()) return TypedResults.NotFound("No students found.");


            return TypedResults.Ok(StudentClassDTO.FromListOfStudents(students));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentById(IStudentRepository repository, int id)
        {
            var student = await repository.GetStudentById(id);
            return student != null ? TypedResults.Ok(new StudentClassDTO(student)) : TypedResults.NotFound($"Student with ID {id} not found.");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IStudentRepository repository, UserPayload payload)
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
                CourseId = payload.CourseId.Value,
                AvarageGrade = payload.AvarageGrade.Value 
            };

            var createdStudent = await repository.CreateStudent(student);
            createdStudent = await repository.GetStudentById(createdStudent.Id);
            return TypedResults.Created($"/students/{createdStudent.Id}", new StudentClassDTO(createdStudent));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudentById(IStudentRepository repository, int id, UserPayload payload)
        {
            var existingStudent = await repository.GetStudentById(id);
            if (existingStudent == null)
            {
                return TypedResults.NotFound($"Student with ID {id} not found.");
            }

            if (payload.FirstName != null) existingStudent.FirstName = payload.FirstName;
            if (payload.LastName != null) existingStudent.LastName = payload.LastName;
            if (payload.DateOfBirth.HasValue) existingStudent.DateOfBirth = payload.DateOfBirth.Value;
            if (payload.CourseId != null) existingStudent.CourseId = payload.CourseId.Value;
            if (payload.AvarageGrade.HasValue) existingStudent.AvarageGrade = payload.AvarageGrade.Value;

            await repository.UpdateStudentById(id, existingStudent);

            return TypedResults.Ok(new StudentClassDTO(existingStudent));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudentById(IStudentRepository repository, int id)
        {
            var deletedStudent = await repository.DeleteStudentById(id);
            return deletedStudent != null ? TypedResults.Ok(new StudentClassDTO(deletedStudent)) : TypedResults.NotFound($"Student with ID {id} not found.");
        }

    }
  

}
