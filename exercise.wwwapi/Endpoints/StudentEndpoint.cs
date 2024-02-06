using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    /// 
    public record StudentPostPayload(string firstname, string lastname, string birthday, string grade);
    public record StudentUpdatePayload(string? firstname, string? lastname, string? birthday, string? grade);

    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/{courseId}", AddStudent);
            students.MapPut("/{id}/courses/{courseId}", ChangeStudent);
            students.MapDelete("/{id}", RemoveStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            //var payload = new Payload<IEnumerable<Student>>() { data = results };

            return TypedResults.Ok(StudentResponseDTO.FromRepository(results));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentPostPayload payload, int courseId)
        {
            //Handling missing inputs
            bool somethingWrong = false;
            string message = "";

            if (payload.firstname == null || payload.firstname == "")
            {
                message += "First name not valid.\n";
                somethingWrong = true;
            }

            if (payload.lastname == null || payload.lastname == "")
            {
                message += "Last name not valid.\n";
                somethingWrong = true;
            }

            if (payload.birthday == null || payload.birthday == "")
            {
                message += "Birthday not valid.";
                somethingWrong = true;
            }

            if (payload.grade == null || payload.grade == "")
            {
                message += "Grade not valid.";
                somethingWrong = true;
            }

            if (somethingWrong)
                return Results.BadRequest(message);

            Student? student = await repository.AddStudent(payload.firstname, payload.lastname, payload.birthday, payload.grade, courseId);
            if (student == null)
                return Results.BadRequest("Student already exists");

            StudentResponseDTO stu = StudentResponseDTO.FromARepository(student);
            return TypedResults.Created($"/students{stu.FirstName} {stu.LastName} {stu.Birthday} {stu.AverageGrade} {stu.LastName}", stu);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> ChangeStudent(IRepository repository, StudentUpdatePayload posted, int studentId, int courseId)
        {
            Student? student = await repository.GetStudent(studentId);
            if (student == null)
                return Results.NotFound("ID out of scope");

            student = await repository.ChangeStudent(student, posted.firstname, posted.lastname, posted.birthday, posted.grade, courseId);
            if (student == null)
                return Results.BadRequest("Student already changed");

            StudentResponseDTO stu = StudentResponseDTO.FromARepository(student);
            return TypedResults.Created($"/students{stu.FirstName} {stu.LastName} {stu.Birthday} {stu.AverageGrade} {stu.LastName}", stu);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> RemoveStudent(IRepository repository, int id)
        {
            Student? student = await repository.GetStudent(id);
            if (student == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(StudentResponseDTO.FromRepository(await repository.RemoveStudent(student)));
        }
    }
}