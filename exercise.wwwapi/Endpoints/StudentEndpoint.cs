using exercise.wwwapi.DataModels.CourseModels;
using exercise.wwwapi.DataModels.StudentModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Services;
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
            students.MapGet("/", GetAll);
            students.MapGet("/{id}", Get);
            students.MapPost("/", Create);
            students.MapPut("/{id}", Update);
            students.MapDelete("/{id}", Delete);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Student> repository)
        {
            var results = await repository.Get();

            IEnumerable<OutputStudent> outputStudent = StudentDtoManager.Convert(results);
            var payload = new Payload<IEnumerable<OutputStudent>>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Student> repository, int id)
        {
            var result = await repository.Get(id);
            if (result == null)
                return TypedResults.NotFound();

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Student> repository, IRepository<Course> courseRepository, InputStudent student)
        {
            Course? course = await courseRepository.Get(student.CourseId);
            if (course == null)
                return TypedResults.NotFound();

            Student newStudent = StudentDtoManager.Convert(student);

            newStudent.Course = course;

            var result = await repository.Create(newStudent);

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(IRepository<Student> studentRepository, IRepository<Course> courseRepository, int id, InputStudent student)
        {
            Student? existingStudent = await studentRepository.Get(id);
            if (existingStudent == null)
                return TypedResults.NotFound();

            Course? course = await courseRepository.Get(student.CourseId);
            if (course == null)
                return TypedResults.NotFound($"Course with id {student.CourseId} not found");

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.AverageGrade = student.AverageGrade;
            existingStudent.CourseId = student.CourseId;
            existingStudent.Course = course;

            var result = await studentRepository.Update(existingStudent);

            OutputStudent outputStudent = StudentDtoManager.Convert(result);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Student> repository, int id)
        {
            Student? existingStudent = await repository.Get(id);
            if (existingStudent == null)
                return TypedResults.NotFound();

            Student studentCopy = new Student
            {
                Id = existingStudent.Id,
                FirstName = existingStudent.FirstName,
                LastName = existingStudent.LastName,
                DateOfBirth = existingStudent.DateOfBirth,
                AverageGrade = existingStudent.AverageGrade,
                CourseId = existingStudent.CourseId,
                Course = existingStudent.Course
            };

            await repository.Delete(id);

            OutputStudent outputStudent = StudentDtoManager.Convert(studentCopy);
            var payload = new Payload<OutputStudent>() { data = outputStudent };
            return TypedResults.Ok(payload);
        }
    }
}
