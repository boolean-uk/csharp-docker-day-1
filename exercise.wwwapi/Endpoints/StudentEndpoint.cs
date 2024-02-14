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
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{studentId}/course/{courseId}", AddCourseToStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentById(IRepository repository, int id)
        {
            var student = await repository.GetStudentById(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            var payload = new Payload<Student>() { data = student };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddCourseToStudent(IRepository repository, int id,  int courseId)
        {
            var student = await repository.GetStudentById(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            student.CourseId = courseId;
            var updatedStudentWCourse = await repository.UpdateStudent(student, id);
            var payload = new Payload<Student>() { data = updatedStudentWCourse };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            await repository.CreateStudent(student);
            var payload = new Payload<Student>() { data = student };
            return Results.Created($"/students/{student.Id}", payload);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, Student student)
        {
            var updatedStudent = await repository.GetStudentById(id);
            if (updatedStudent == null)
            {
                return Results.NotFound();
            }

            var updated = await repository.UpdateStudent(student, id);

            var payload = new Payload<Student>() { data = updated };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var deletedStudent = await repository.GetStudentById(id);
            if (deletedStudent == null)
            {
                return Results.NotFound();
            }
            await repository.DeleteStudent(id);
            var payload = new Payload<Student>() { data = deletedStudent };
            return TypedResults.Ok(payload);
        }


    }
}
