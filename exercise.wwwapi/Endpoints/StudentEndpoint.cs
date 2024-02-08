using exercise.wwwapi.DataTransferObjects.StudentDTO;
using exercise.wwwapi.Payloads;
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
            students.MapPut("/", AddStudent);
            students.MapPost("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPost("/{studentId}/course/{courseId}", ApplyToCourse);
            students.MapPatch("/{id}/course", LeaveCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var returnStudents = new List<StudentDTO>();
            var students = await repository.GetStudents();
            foreach (var student in students)
            {
                returnStudents.Add(new StudentDTO(student));
            }

            return TypedResults.Ok(returnStudents);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, CreateStudentPayload payload)
        {
            //Check DateTimes
            if (string.IsNullOrWhiteSpace(payload.FirstName) || string.IsNullOrWhiteSpace(payload.LastName) || float.IsNaN(payload.AverageGrade))
            {
                return TypedResults.BadRequest("Incomplete student data.");
            }

            var student = await repository.AddStudent(payload.FirstName, payload.LastName, payload.Birthdate, payload.AverageGrade);
            return TypedResults.Created($"students/{student.Id}", new StudentDTO(student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, int id, UpdateStudentPayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.FirstName) && string.IsNullOrWhiteSpace(payload.LastName) &&
                payload.Birthdate == null && float.IsNaN(payload.AverageGrade))
            {
                return TypedResults.BadRequest("Empty data");
            }

            var student = await repository.UpdateStudent(id, payload.FirstName, payload.LastName, payload.Birthdate, payload.AverageGrade);
            return student == null ? TypedResults.NotFound("Student not found") : TypedResults.Ok(new StudentDTO(student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, int id)
        {
            var student = await repository.DeleteStudent(id);
            return student == null ? TypedResults.NotFound("Student not found") : TypedResults.Ok(new StudentDTO(student));
        }

        public static async Task<IResult> ApplyToCourse(IStudentRepository repository, int studentId, int courseId)
        {
            try
            {
                var student = await repository.ApplyToCourse(studentId, courseId);
                return student == null ? TypedResults.NotFound("Student not found") : TypedResults.Ok(new StudentDTO(student));
            }
            catch (KeyNotFoundException ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }

        }
        public static async Task<IResult> LeaveCourse(IStudentRepository repository, int id)
        {
            var student = await repository.LeaveCourse(id);
            return student == null ? TypedResults.NotFound("Student not found") : TypedResults.Ok(new StudentDTO(student));
        }
    }
}
