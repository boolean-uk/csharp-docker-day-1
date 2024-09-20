using System.Globalization;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http;
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
            var payload = new Payload<List<DTOStudent>>() { Data = new List<DTOStudent>() };
            foreach (var student in results)
            {
                CourseForStudent dtoCourse = new CourseForStudent() { Id = student.CourseId, Title = student.course.Title };
                payload.Data.Add(new DTOStudent() { Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth, Course = dtoCourse });
            }
            
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentPostModel model)
        {
            try
            {
                if (await repository.GetCourseById(model.CourseId) == null)
                {
                    return TypedResults.NotFound(new Payload<string>() { Data = "Course does not exist in database"});
                }
             
                DateTime dateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd.MM.yyyy", CultureInfo.CurrentCulture); 

                Student student = await repository.AddStudent(new Student { FirstName = model.FirstName, LastName = model.LastName, DateOfBirth = dateOfBirth, CourseId = model.CourseId });
                CourseForStudent dtoCourse = new CourseForStudent() { Id = student.CourseId, Title = student.course.Title };
                DTOStudent dtoStudent = new DTOStudent() { Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth, Course = dtoCourse };

                return TypedResults.Created("", new Payload<DTOStudent>() { Data = dtoStudent });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(IRepository repository, int id, StudentPostModel model)
        {
            try
            {
                Student toUpdate = await repository.GetStudentById(id);
                if (toUpdate == null)
                {
                    return TypedResults.NotFound(new Payload<string>() { Data = "Student does not exist in database" });
                }

                if (await repository.GetCourseById(model.CourseId) == null)
                {
                    return TypedResults.NotFound(new Payload<string>() { Data = "Course does not exist in database" });
                }

                
                DateTime dateOfBirth = DateTime.ParseExact(model.DateOfBirth, "dd.MM.yyyy", CultureInfo.CurrentCulture);

                toUpdate.FirstName = model.FirstName;
                toUpdate.LastName = model.LastName;
                toUpdate.DateOfBirth = dateOfBirth;
                toUpdate.CourseId = model.CourseId;
                Student student = await repository.UpdateStudent(toUpdate);

                CourseForStudent dtoCourse = new CourseForStudent() { Id = student.CourseId, Title = student.course.Title };
                DTOStudent dtoStudent = new DTOStudent() { Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth, Course = dtoCourse };
                return TypedResults.Created("", new Payload<DTOStudent>() { Data = dtoStudent });
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }

        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, int id)
        {
            
            Student toDelete = await repository.GetStudentById(id);
            if (toDelete == null)
            {
                return TypedResults.NotFound(new Payload<string>() { Data = "Student does not exist in database" });
            }

            Student student = await repository.DeleteStudent(toDelete);

            CourseForStudent dtoCourse = new CourseForStudent() { Id = student.CourseId, Title = student.course.Title };
            DTOStudent dtoStudent = new DTOStudent() { Id = student.Id, Name = $"{student.FirstName} {student.LastName}", DateOfBirth = student.DateOfBirth, Course = dtoCourse };
            return TypedResults.Ok(new Payload<DTOStudent>() { Data = dtoStudent });
            
        }

    }
  

}
