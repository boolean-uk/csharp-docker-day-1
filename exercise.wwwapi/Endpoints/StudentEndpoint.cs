using exercise.wwwapi.DataModels.Course;
using exercise.wwwapi.DataModels.Student;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

/// <summary>
/// Core Endpoint
/// </summary>
public static class StudentEndpoint
{
    public static void StudentEndpointConfiguration(this WebApplication app)
    {
        var students = app.MapGroup("students");
        students.MapPost("/", CreateStudent);
        students.MapGet("/", GetStudents);
        students.MapGet("/{id}", GetStudent);
        students.MapPut("/{id}", UpdateStudent);
        students.MapDelete("/{id}", DeleteStudent);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> CreateStudent(IRepository<Student> repository, IRepository<Course> courseRepository, PostStudent studentData)
    {
        var student = new Student()
        {
            FirstName = studentData.FirstName,
            LastName = studentData.LastName,
            DateOfBirth = studentData.DateOfBirth,
            CourseId = studentData.CourseId,
            AverageGrade = studentData.AverageGrade,
            StartDate = studentData.StartDate,
        };
        var course = courseRepository.GetById(studentData.CourseId);
        if (course == null)
        {
            return TypedResults.NotFound($"There is no course with the id: {studentData.CourseId}!");
        }
        var result = await repository.Create(student);
        var payload = new Payload<Student>() { data = result };
        return TypedResults.Created($"/{student.Id}", payload);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetStudents(IRepository<Student> repository)
    {
        var results = await repository.GetAll();
        var payload = new Payload<IEnumerable<Student>>() { data = results };
        return TypedResults.Ok(payload);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
    {
        var result = await repository.GetById(id);
        if (result == null)
        {
            return TypedResults.NotFound($"There is no Student with the id: {id}!");
        }
        var payload = new Payload<Student>() { data = result };
        return TypedResults.Ok(payload);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> UpdateStudent(IRepository<Student> repository, IRepository<Course> courseRepository, int id, PostStudent studentData)
    {   
        var toEdit = await repository.GetById(id);
        if (toEdit == null)
        {
            return TypedResults.NotFound($"There is no Student with the id: {id}!");
        }
        toEdit.FirstName = studentData.FirstName;
        toEdit.LastName = studentData.LastName;
        toEdit.DateOfBirth = studentData.DateOfBirth;
        toEdit.CourseId = studentData.CourseId;
        toEdit.AverageGrade = studentData.AverageGrade;
        toEdit.StartDate = studentData.StartDate;
        var course = await courseRepository.GetById(studentData.CourseId);
        if (course == null)
        {
            return TypedResults.NotFound($"There is no course with the id: {studentData.CourseId}!");
        }
        var result = await repository.Update(toEdit);
        result.Course = course;
        var payload = new Payload<Student>() { data = result };
        return TypedResults.Ok(payload);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
    {
        var result = await repository.Delete(id);
        if (result == null)
        {
            return TypedResults.NotFound($"There is no Student with the id: {id}!");
        }
        var payload = new Payload<Student>() { data = result };
        return TypedResults.Ok(payload);
    }

}

