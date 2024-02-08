using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}/", UpdateStudent);
            students.MapDelete("/{id}/", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var students = await repository.GetStudents();
            var studentDto = new List<StudentResponseDTO>();
            foreach (Student student in students)
            {
                studentDto.Add(new StudentResponseDTO(student));
            }
            return TypedResults.Ok(studentDto);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(CreateStudentPayload payload, IRepository repository)
        {
            if (payload.FirstName == null || payload.LastName == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }

            Student? student = await repository.CreateStudent(payload.FirstName, payload.LastName, payload.DateOfBirth, payload.avgGrade);
            if (student == null)
            {
                return Results.BadRequest("Failed to create student.");
            }

            return TypedResults.Ok(new StudentResponseDTO(student));
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(int studentId, UpdateStudentPayload payload, IRepository Repository)
        {
            Student? student = await Repository.GetAStudent(studentId);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found");
            }
            Student? studentUpdated = await Repository.UpdateStudent(studentId, payload.newFirstName, payload.newLastName, payload.newDateOfBirth, payload.avgGrade);
            if (studentUpdated == null)
            {
                return Results.BadRequest("Failed to update student.");
            }

            return TypedResults.Created($"/students/{studentUpdated.Id}", new StudentResponseDTO(studentUpdated));
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteStudent(int studentId, IRepository repository)
        {
            Student? student = await repository.GetAStudent(studentId);
            if (student == null)
            {
                return TypedResults.NotFound("Student not found");
            }
            Student? studentDelete = await repository.DeleteStudent(studentId);
            if (studentDelete == null)
            {
                return Results.BadRequest("Failed to delete student.");
            }

            return TypedResults.Ok(new StudentResponseDTO(student));
        }

    }


}
