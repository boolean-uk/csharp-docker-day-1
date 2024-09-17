using exercise.wwwapi.DataModels;
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
        private static string _path = AppContext.BaseDirectory;
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var resultList = await repository.GetAll(inclusions: ["Course"]);
            var resultDTOs = new List<ResponseStudentDTO>();
            foreach (var result in resultList)
            {
                resultDTOs.Add(new ResponseStudentDTO(result));
            }
            var payload = new Payload<IEnumerable<ResponseStudentDTO>>() { Status = "Success", Data = resultDTOs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository, int id)
        {
            var result = await repository.Get(inclusions: ["Course"], predicate: x => x.Id == id);
            var resultDTO = new ResponseStudentDTO(result);
            var payload = new Payload<ResponseStudentDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, PostStudentDTO model)
        {
            var result = await repository.Create(
                inclusions: ["Course"],
                model: new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = DateTime.Parse(model.DateOfBirth).ToUniversalTime(),
                    CourseId = model.CourseId
                });

            var resultDTO = new ResponseStudentDTO(result);

            var payload = new Payload<ResponseStudentDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, PutStudentDTO model)
        {
            var result = await repository.Create(
                inclusions: ["Course"],
                model: new Student()
                {
                    Id = id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = DateTime.Parse(model.DateOfBirth).ToUniversalTime(),
                    CourseId = model.CourseId
                });

            var resultDTO = new ResponseStudentDTO(result);

            var payload = new Payload<ResponseStudentDTO>() { Status = "Success", Data = resultDTO };
            return TypedResults.Created(_path, payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            var result = await repository.Delete(inclusions: ["Course"], model: new Student() { Id = id });
            var resultDTO = new ResponseStudentDTO(result);
            var payload = new Payload<ResponseStudentDTO>() { Data = resultDTO };
            return TypedResults.Ok(payload);
        }
    }
}
