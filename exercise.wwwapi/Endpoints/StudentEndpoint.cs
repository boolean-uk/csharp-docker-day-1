using AutoMapper;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DataTransferObjects.Course;
using exercise.wwwapi.DataTransferObjects.Student;
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
            students.MapPost("/", CreateStudent);
            students.MapPut("/{id}", UpdateStudent);
            students.MapDelete("/{id}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository, IMapper mapper)
        {
            var source = await repository.GetAll();
            //Trannsferring:

           /* List<OutStudentDTO> results = source.Select(s => new OutStudentDTO
            {
                AverageGrade = s.AverageGrade,
                DoB = s.DoB,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Course = new OutCourseDTO { 
                    Id = s.Course.Id,
                    Title = s.Course.Title,
                    CourseStartDate = s.Course.CourseStartDate
                }
            }).ToList();*/

           List<OutStudentDTO> results = source.Select(mapper.Map<OutStudentDTO>).ToList();

            //var payload = new Payload<IEnumerable<OutStudentDTO>>() { data = results };       //This does not work..
            var payload = new Payload<List<OutStudentDTO>>() { data = results };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository<Student> repository, IMapper mapper, [FromBody] InStudentDTO newStudent)
        {
            Payload<OutStudentDTO> response = new();

            try
            {
                Student student = mapper.Map<Student>(newStudent);

                // source: 
                var source = await repository.Add(student);
                //Transferring:
                response.data = mapper.Map<OutStudentDTO>(source);
                return TypedResults.Created(nameof(CreateStudent), response);
            }

            catch (Exception ex)
            {
                return TypedResults.BadRequest(response);
            }


        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, IMapper mapper, [FromBody] InStudentDTO newStudent, [FromQuery] int id) {
            
            Payload<OutStudentDTO> response = new();

            try
            {
                Student student = mapper.Map<Student>(newStudent);
                student.Id = id; 
                // source: 
                var source = await repository.UpdateById(student, id);
                //Transferring:

                response.data = mapper.Map<OutStudentDTO>(source);
                return TypedResults.Ok(response);
            }

            catch (Exception ex)
            {
                return TypedResults.NotFound(response);
            }

        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, IMapper mapper, [FromQuery] int id) {
            
            Payload<OutStudentDTO> response = new();

            try
            {
                // source: 
                var source = await repository.DeleteById(id);
                //Transferring:
                response.data = mapper.Map<OutStudentDTO>(source);
                return TypedResults.Ok(response);
            }

            catch (Exception ex)
            {
                return TypedResults.NotFound(response);
            }

        }




        


    }
}
