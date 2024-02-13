using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTO;
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
            students.MapPut("/{id}", Update);
            students.MapPost("/", Create);
            students.MapDelete("/{id}", Delete);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.Get();
            var payload = new Payload<IEnumerable<Student>>(results);
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Update(IRepository<Student> repository, int id, StudentPut studentData) 
        {
            Student student = await repository.GetById(id);
            student.FirstName = studentData.FirstName == string.Empty ? student.FirstName : studentData.FirstName;
            student.LastName = studentData.LastName == string.Empty ? student.LastName : studentData.LastName;
            student.DateofBirth = studentData.DateofBirth == string.Empty ? student.DateofBirth : studentData.DateofBirth;
            student.CourseTitle = studentData.CourseTitle == string.Empty ? student.CourseTitle : studentData.CourseTitle;
            student.Startdate = studentData.Startdate == DateTime.MinValue ? student.Startdate : studentData.Startdate;
            student.AvgGrade = studentData.AvgGrade <= 0 ? student.AvgGrade : studentData.AvgGrade;
            student.CourseId = studentData.CourseId <= 0 ? student.CourseId : studentData.CourseId;

            Student updatedStudent = await repository.Update(student);
            Payload<Student> payload = new Payload<Student>(updatedStudent);
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Create(IRepository<Student> repository, StudentPut studentData) 
        {
            Student student = new Student
            {
                FirstName = studentData.FirstName,
                LastName = studentData.LastName,
                DateofBirth = studentData.DateofBirth,
                CourseTitle = studentData.CourseTitle,
                Startdate = studentData.Startdate,
                AvgGrade = studentData.AvgGrade,
                CourseId = studentData.CourseId
            };

            Student result = await repository.Add(student);
            Payload<Student> payload = new Payload<Student>(result);
            return TypedResults.Ok(payload);
        }

        public static async Task<IResult> Delete(IRepository<Student> repository, int id) 
        {
            Student student = await repository.GetById(id);
            Student result = await repository.Delete(student);
            Payload<Student> payload = new Payload<Student>(result);
            return TypedResults.Ok(payload);
        }

    }
  

}
