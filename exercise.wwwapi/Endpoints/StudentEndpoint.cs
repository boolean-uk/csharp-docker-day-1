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
            students.MapPost("/", AddStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = await repository.GetStudents();
            var payload = new Payload<IEnumerable<Student>>() { data = results };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentInput student)
        {
            if (!student.FirstName.Any() || !student.LastName.Any()) return TypedResults.BadRequest();
            if (await repository.GetCourse(student.CourseId) == null) return TypedResults.BadRequest();

            var result = await repository.AddStudent(new Student { FirstName = student.FirstName, LastName = student.LastName, DateOfBirth = student.DateOfBirth, CourseId = student.CourseId, AverageGrade = student.AverageGrade });
            Payload<Student> payload = new () { data = repository.GetStudent(result.Id).Result };
            return TypedResults.Created($"{result.Id}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, StudentInput studentData)
        {
            if (!studentData.FirstName.Any() || !studentData.LastName.Any()) return TypedResults.BadRequest();
            if (await repository.GetCourse(studentData.CourseId) == null) return TypedResults.BadRequest();

            var student = await repository.GetStudent(id);
            if (student == null) return TypedResults.NotFound();

            student.Update(studentData);

            var result = await repository.UpdateStudent(student);
            Payload<Student> payload = new () { data = repository.GetStudent(result.Id).Result };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            var student = await repository.GetStudent(id);
            if (student == null) return TypedResults.NotFound();

            await repository.DeleteStudent(student);
            return TypedResults.Ok();
        }

    }
  

}
