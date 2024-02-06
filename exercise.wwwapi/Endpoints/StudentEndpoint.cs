using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.DTOs;

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

            var studentDTO = new List<StudentDTO>();

            foreach (Student s in results)
            {
                studentDTO.Add(new StudentDTO(s));
            }

            return TypedResults.Ok(studentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetStudent(int StudentId, IRepository repository)
        {

            Student? d = await repository.GetStudent(StudentId, PreloadPolicy.PreloadRelations);

            if (d == null)
            {
                return Results.NotFound("Student not found");
            }

            var StudentDTO = new StudentDTO(d);

            return TypedResults.Ok(StudentDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteStudent(int StudentId, IRepository repository)
        {

            Student? d = await repository.DeleteStudent(StudentId, PreloadPolicy.PreloadRelations);

            if (d == null)
            {
                return Results.NotFound("Student not found");
            }

            var StudentDTO = new StudentDTO(d);

            repository.SaveChanges();

            return TypedResults.Ok(StudentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(CreateStudentPayload payload, IRepository repository)
        {

            if (payload.FirstName == null || payload.LastName == "")
            {
                return Results.BadRequest("A non-empty Name is required");
            }

            Student? d = await repository.CreateStudent(payload.FirstName, payload.LastName, payload.DOB, payload.CourseId, payload.AverageGrade);
            
            if (d == null)
            {
                return Results.BadRequest("Failed to create Student.");
            }

            repository.SaveChanges();

            return TypedResults.Ok(new StudentDTO(d));
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(int id, StudentUpdatePayload payload, IRepository repository)
        {

            var ogcust = repository.GetStudents().Result.FirstOrDefault(x => x.Id == id);

            if (ogcust == null)
            {
                return Results.BadRequest("The Student does not exist.");
            }

            if (payload.FirstName == "" && payload.LastName == "")
            {
                return Results.BadRequest("Non-empty fields are required");
            }


            Student? Student = await repository.UpdateStudent(id, payload.FirstName, payload.LastName, payload.DOB, payload.CourseId, payload.AverageGrad, PreloadPolicy.DoNotPreloadRelations);


            if (Student == null)
            {
                return Results.BadRequest("Failed to create Student.");
            }

            repository.SaveChanges();

            StudentDTO cdto = new StudentDTO(Student);

            return TypedResults.Created($"/Students{Student.Id}", cdto);
        }
       
    }
}
    