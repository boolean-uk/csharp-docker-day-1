using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/" , GetStudents);
            students.MapGet("/{id}" , GetStudent);
            students.MapPost("/" , CreateStudent);
            students.MapPut("/{id}" , UpdateStudent);
            students.MapDelete("/{id}" , DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var students = await repository.GetStudentsAsync();
            var studentDtos = students.Select(s => new StudentDto
            {
                Id = s.Id ,
                FirstName = s.FirstName ,
                LastName = s.LastName ,
                DateOfBirth = s.DateOfBirth ,
                CourseTitle = s.CourseTitle ,
                StartDate = s.StartDate ,
                AverageGrade = s.AverageGrade ,
                CourseId = s.CourseId
            });
            var payload = new Payload<IEnumerable<StudentDto>>() { data = studentDtos };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(Guid id , IStudentRepository repository)
        {
            var student = await repository.GetStudentAsync(id);
            if(student == null)
            {
                return TypedResults.NotFound();
            }
            var studentDto = new StudentDto
            {
                Id = student.Id ,
                FirstName = student.FirstName ,
                LastName = student.LastName ,
                DateOfBirth = student.DateOfBirth ,
                CourseTitle = student.CourseTitle ,
                StartDate = student.StartDate ,
                AverageGrade = student.AverageGrade ,
                CourseId = student.CourseId
            };
            var payload = new Payload<StudentDto>() { data = studentDto };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(StudentDto studentDto , IStudentRepository repository)
        {
            var student = new Student
            {
                Id = studentDto.Id ,
                FirstName = studentDto.FirstName ,
                LastName = studentDto.LastName ,
                DateOfBirth = studentDto.DateOfBirth ,
                CourseTitle = studentDto.CourseTitle ,
                StartDate = studentDto.StartDate ,
                AverageGrade = studentDto.AverageGrade ,
                CourseId = studentDto.CourseId
            };
            var createdStudent = await repository.AddStudentAsync(student);
            var createdStudentDto = new StudentDto
            {
                Id = createdStudent.Id ,
                FirstName = createdStudent.FirstName ,
                LastName = createdStudent.LastName ,
                DateOfBirth = createdStudent.DateOfBirth ,
                CourseTitle = createdStudent.CourseTitle ,
                StartDate = createdStudent.StartDate ,
                AverageGrade = createdStudent.AverageGrade ,
                CourseId = createdStudent.CourseId
            };
            return Results.Created($"/students/{createdStudentDto.Id}" , createdStudentDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(Guid id , StudentDto studentDto , IStudentRepository repository)
        {
            if(id != studentDto.Id)
            {
                return TypedResults.BadRequest();
            }
            var student = new Student
            {
                Id = studentDto.Id ,
                FirstName = studentDto.FirstName ,
                LastName = studentDto.LastName ,
                DateOfBirth = studentDto.DateOfBirth ,
                CourseTitle = studentDto.CourseTitle ,
                StartDate = studentDto.StartDate ,
                AverageGrade = studentDto.AverageGrade ,
                CourseId = studentDto.CourseId
            };
            var updatedStudent = await repository.UpdateStudentAsync(student);
            var updatedStudentDto = new StudentDto
            {
                Id = updatedStudent.Id ,
                FirstName = updatedStudent.FirstName ,
                LastName = updatedStudent.LastName ,
                DateOfBirth = updatedStudent.DateOfBirth ,
                CourseTitle = updatedStudent.CourseTitle ,
                StartDate = updatedStudent.StartDate ,
                AverageGrade = updatedStudent.AverageGrade ,
                CourseId = updatedStudent.CourseId
            };
            var payload = new Payload<StudentDto>() { data = updatedStudentDto };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public static async Task<IResult> DeleteStudent(Guid id , IStudentRepository repository)
        {
            await repository.DeleteStudentAsync(id);
            return TypedResults.NoContent();
        }
    }
}
