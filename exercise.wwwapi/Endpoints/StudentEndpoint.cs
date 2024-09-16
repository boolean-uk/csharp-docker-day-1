using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataViews;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Core Endpoint
    /// </summary>
    public static class StudentEndpoint
    {
        private static string _path = AppContext.BaseDirectory;
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var resultList = await repository.GetAll(["Course"]);
            var resultDTOs = new List<StudentDTO>();
            foreach (var result in resultList)
            {
                resultDTOs.Add(new StudentDTO(result));
            }
            var payload = new Payload<IEnumerable<StudentDTO>>() { Data = resultDTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, StudentView view)
        {
            var model = new Student()
            { 
                FirstName = view.FirstName,
                LastName = view.LastName,
                DateOfBirth = DateTime.Parse(view.DateOfBirth).ToUniversalTime(),
                CourseId = view.CourseId
            };
            var result = await repository.Create(["Course"], model);
            var resultDTO = new StudentDTO(result);

            var payload = new Payload<StudentDTO>() { Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, StudentView view)
        {
            var model = new Student()
            {
                Id = id,
                FirstName = view.FirstName,
                LastName = view.LastName,
                DateOfBirth = DateTime.Parse(view.DateOfBirth).ToUniversalTime(),
                CourseId = view.CourseId
            };
            var result = await repository.Update(["Course"], model);
            var resultDTO = new StudentDTO(result);

            var payload = new Payload<StudentDTO>() { Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var result = await repository.Delete(["Course"], new Student() { Id = id });
            var resultDTO = new StudentDTO(result);
            var payload = new Payload<StudentDTO>() { Data = resultDTO };
            return TypedResults.Ok(payload);
        }

    }
  

}
