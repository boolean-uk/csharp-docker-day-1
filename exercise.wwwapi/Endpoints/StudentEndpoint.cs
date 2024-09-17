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
        public static void StudentEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetAStudent);
            students.MapPost("/", CreateStudent);
            students.MapDelete("/{id}", DeleteStudent);
            students.MapPut("/{id}", UpdateStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var results = await repository.GetAll();

            List<GetStudentDTO> studs = new List<GetStudentDTO>();

            foreach (var student in results) 
            {
                GetStudentDTO studentDTO = new GetStudentDTO()
                { 
                    Name = $"{student.FirstName} {student.LastName}", 
                    DateOfBirth = student.DateOfBirth, 
                    CourseTitle = student.Course.CourseTitle,
                    AverageGrade = student.AverageGrade,
                };

                studs.Add(studentDTO);
            }

            var payload = new Payload<IEnumerable<GetStudentDTO>>() { Data = studs };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAStudent(IRepository<Student> repository, int id)
        {
            try
            {
                var result = await repository.GetById(id);

                    GetStudentDTO studentDTO = new GetStudentDTO()
                    {
                        Name = $"{result.FirstName} {result.LastName}",
                        DateOfBirth = result.DateOfBirth,
                        CourseTitle = result.Course.CourseTitle,
                        AverageGrade = result.AverageGrade,
                    };
                
                var payload = new Payload<GetStudentDTO>() { Data = studentDTO };
                return TypedResults.Ok(payload);
            }
            catch (Exception)
            {
                return TypedResults.NotFound($"Student with id {id} not found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, PostPutStudentDTO newValues)
        {
            try
            {

                var newStudent = new Student() 
                { 
                    FirstName = newValues.FirstName, 
                    LastName = newValues.LastName,
                    DateOfBirth = DateOnly.Parse(newValues.DateOfBirth),
                    CourseId = newValues.CourseId, 
                    CourseStart = newValues.CourseStart, 
                    AverageGrade = newValues.AverageGrade,
                };

                var result = await repository.Create(newStudent);

                var target = await repository.GetById(result.Id);

                GetStudentDTO studentDTO = new GetStudentDTO()
                {
                    Name = $"{target.FirstName} {target.LastName}",
                    DateOfBirth = target.DateOfBirth,
                    CourseTitle = target.Course.CourseTitle,
                    AverageGrade = target.AverageGrade,
                };

                var payload = new Payload<GetStudentDTO>() { Data = studentDTO };
                var path = $"/students/{target.Id}";
                return TypedResults.Created(path, payload);

            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, int id)
        {
            try
            {
               await repository.Delete(id);
               return TypedResults.Ok($"Student with id {id} deleted!");
            }
            catch (Exception)
            {
                return TypedResults.NotFound($"Student with id {id} not found");
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, int id, PostPutStudentDTO newValues)
        {
            try
            {
                var target = await repository.GetById(id);

                if (target == null)
                {
                    return TypedResults.NotFound($"Student with id {id} not found");
                }

                target.FirstName = newValues.FirstName;
                target.LastName = newValues.LastName;
                target.DateOfBirth = DateOnly.Parse(newValues.DateOfBirth);
                target.CourseId = newValues.CourseId;
                target.CourseStart = newValues.CourseStart;
                target.AverageGrade = newValues.AverageGrade;

                var result = await repository.Update(target);

                GetStudentDTO studentDTO = new GetStudentDTO()
                {
                    Name = $"{target.FirstName} {target.LastName}",
                    DateOfBirth = target.DateOfBirth,
                    CourseTitle = target.Course.CourseTitle,
                    AverageGrade = target.AverageGrade,
                };

                var payload = new Payload<GetStudentDTO>() { Data = studentDTO };
                var path = $"/student/{target.Id}";
                return TypedResults.Created(path, payload);
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
