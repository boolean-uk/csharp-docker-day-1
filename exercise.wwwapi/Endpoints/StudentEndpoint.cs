using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint GET/PUT/POST/DELETE
    /// </summary>
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{student.Id}", GetStudent);
            students.MapPut("/{student.Id}", UpdateStudent);
            students.MapPost("/{student.Id}", CreateStudent);
            students.MapDelete("/{student.Id}", DeleteStudent);
            students.MapPost("/{student.Id}/{course.Id}", EnrollStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var results = GetStudentDTO.FromRepository(await repository.GetStudents());
            var payload = new Payload<IEnumerable<GetStudentDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> GetStudent(IRepository repository, int id)
        {
            var student = new GetStudentDTO(await repository.GetStudent(id));
            if(student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            var payload = new Payload<GetStudentDTO>() { data = student };
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> UpdateStudent(IRepository repository, StudentUpdatePayload data, int id)
        {
            //Get student with id and check if exists
            var student = new StudentDTO(await repository.GetStudent(id));
            if (student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            //Check payload data is valid
            if(data.FirstName == null || data.LastName==null || data.Dob == null || data.CourseId == null || data.AvgGrade == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Update student in repository via UpdateStudent()
            student = new StudentDTO(await repository.UpdateStudent(id, data.FirstName, data.LastName, data.Dob, data.CourseId, data.AvgGrade));
            var payload = new Payload<StudentDTO>() { data = student };
            //Return TypedResults.created
            return TypedResults.Created($"/{student.Id}", payload);
        }
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPostPayload data)
        {
            //Check payload data is valid
            if(data.FirstName == null || data.LastName == null || data.Dob == null || data.CourseId == null || data.AvgGrade == null)
            {
                return TypedResults.BadRequest($"You must fill all fields.");
            }
            //Create new student in repo via CreateStudent()
            var student = new StudentDTO(await repository.CreateStudent(data.FirstName, data.LastName, data.Dob, data.CourseId, data.AvgGrade));
            var payload = new Payload<StudentDTO>() { data = student };
            return TypedResults.Created($"/{student.Id}", payload);
        }
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            //Get student with id and check if exists
            var student = new GetStudentDTO(await repository.GetStudent(id));
            if (student == null)
            {
                return TypedResults.NotFound($"No student with id {id} found.");
            }
            //Run DeleteStudent()
            student = new GetStudentDTO(await repository.DeleteStudent(id));
            var payload = new Payload<GetStudentDTO>() { data = student };
            //Return TypedResults.Ok
            return TypedResults.Ok(payload);
        }
        public static async Task<IResult> EnrollStudent(IRepository repository, EnrollmentPostPayload data)
        {
            //Check that data from payload is valid
            if(data.StudentId == null || data.CourseId == null)
            {
                return TypedResults.BadRequest("You must fill all fields.");
            }
            //Load student to enroll and course to enroll them in (Also check they exist)
            Student? student = await repository.GetStudent(data.StudentId);
            if (student == null)
            {
                return TypedResults.NotFound($"No student with id{data.StudentId} found");
            }
            Course? course = await repository.GetCourse(data.CourseId);
            if(course == null)
            {
                return TypedResults.NotFound($"No course with id{data.CourseId} found");
            }

            //Run CreateEnrollment method and return .Created
            var enrollment = new GetEnrollmentsDTO(await repository.CreateEnrollment(student, course));
            var payload = new Payload<GetEnrollmentsDTO>() { data = enrollment };
            return TypedResults.Created($"/{student.Id}/{course.Id}", payload);
        }
    }
}
