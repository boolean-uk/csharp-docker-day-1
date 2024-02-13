using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

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
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);

            var courses = app.MapGroup("courses");

        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();

            var DTOs = from student in results
                       select new StudentDTO() 
                       {
                           Id = student.Id,
                           FirstName = student.FirstName,
                           LastName = student.LastName,
                           DateOfBirth = student.DateOfBirth,
                           AverageGrade = student.AverageGrade,
                           CourseTitle = student.CourseTitle,
                       };
            var payload = new Payload<IEnumerable<StudentDTO>>() { data = DTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> CreateStudent(IRepository<Student> repository, PostStudent student)
        {
            Payload<StudentDTO> payload = new Payload<StudentDTO>();

            var entity = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
            };
            await repository.Create(entity);

            var result = new StudentDTO()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                AverageGrade = student.AverageGrade,
            };
            payload.data = result;

            return TypedResults.Created(payload.status, payload);
        }

        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, PutStudent model)
        {
            Payload<StudentDTO> payload = new Payload<StudentDTO>();

            var entity = await repository.Get(id);
            if (entity == null)
            {
                payload.status = "Not found";
                payload.data = null;
                return TypedResults.NotFound(payload);
            }
            entity.FirstName = model.FirstName ?? entity.FirstName;
            entity.LastName = model.LastName ?? entity.LastName;
            entity.DateOfBirth = model.DateOfBirth ?? entity.DateOfBirth;
            entity.CourseTitle = model.CourseTitle ?? entity.CourseTitle;
            entity.AverageGrade = model.AverageGrade ?? entity.AverageGrade;

            var update = new StudentDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = (DateTime)model.DateOfBirth,
                CourseTitle = model.CourseTitle,
                AverageGrade = (double)model.AverageGrade,
            };
            await repository.Update(entity);
            payload.data = update;

            return TypedResults.Created(payload.status, payload);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            Payload<StudentDTO> payload = new Payload<StudentDTO>();
            var result = await repository.Delete(id);
            if (result == null)
            {
                payload.status = "Not Found";
                payload.data = null;
                return TypedResults.NotFound(payload);
            }

            var delete = new StudentDTO()
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                DateOfBirth = (DateTime)result.DateOfBirth,
                CourseTitle = result.CourseTitle,
                AverageGrade = (double)result.AverageGrade,
            };
            payload.data = delete;
            return TypedResults.Ok(payload);
        }
    }


}
