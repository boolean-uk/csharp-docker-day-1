using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.PostModels;
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
            students.MapGet("/{id}" ,GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetStudents();
            ICollection<object> students = new List<object>();
            foreach (var student in results)
            {
                students.Add( student.DtObject());
            }
            var payload = new Payload<IEnumerable<object>>() { data = students };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository,IRepository<Course> courseRepository, int id)
        {
            Student results = await repository.GetById(id);
            results.Course = await courseRepository.GetById(results.CourseId);
            var payload = new Payload<object>() { data = results.DtObject() };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, NewStudent model)
        {
            var results = await repository.Insert(new Student() { FirstName = model.FirstName, 
                LastName = model.LastName, 
                AverageGrade = model.AverageGrade,
                CourseDate = model.CourseDate, 
                CourseId = model.CourseId!=0? model.CourseId:-1, 
                DateOfBirth = model.DateOfBirth }); ;
            var payload = new Payload<object>() { data = results.DtObject() };
            return results != null?TypedResults.Ok(payload): TypedResults.BadRequest("Input not valid");
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, PatchStudent model, int id)
        {
            var student = await repository.GetById(id);
            student.CourseDate = (DateTime)(model.CourseDate != null? model.CourseDate:student.CourseDate);
            student.CourseId = (int)(model.CourseId !=null? model.CourseId:student.CourseId);
            student.FirstName = model.FirstName!=null? model.FirstName:student.FirstName;
            student.LastName = model.LastName!=null? model.LastName:student.LastName;
            student.DateOfBirth = (DateTime)(model.DateOfBirth!=null ? model.DateOfBirth:student.DateOfBirth);
            student.AverageGrade = (double)(model.AverageGrade!=null? model.AverageGrade:student.AverageGrade);
            var results = await repository.Update(student);
            var payload = new Payload<object>() { data = results.DtObject() };
            return TypedResults.Ok(payload);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var results = await repository.Delete(id);
            var payload = new Payload<object>() { data = results.DtObject() };
            return TypedResults.Ok(payload);
        }

    }
  

}
