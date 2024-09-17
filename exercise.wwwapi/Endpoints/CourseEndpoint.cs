using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class CourseEndpoint
    {
        public static void CourseEndpointConfiguration(this WebApplication app)
        {
            var students = app.MapGroup("courses");
            students.MapGet("/", GetCourses);
        }
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {

            var results = await repository.GetAll();
            List<CourseDTO> courseDTOs = new List<CourseDTO>();

            foreach (var course in results)
            {
                List<StudentDTO> studentDTOs = new List<StudentDTO>();
                foreach (var student in course.Students)
                {
                    StudentDTO studentDTO = new StudentDTO()
                    {
                        CourseName = course.Name,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth
                    };
                    studentDTOs.Add(studentDTO);
                }

                CourseDTO courseDTO = new CourseDTO()
                {
                    Name = course.Name,
                    Students = studentDTOs
                };
                courseDTOs.Add(courseDTO);
            }
            var payload = new Payload<IEnumerable<CourseDTO>>() { Data = courseDTOs };
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository<Course> repository, int id)
        {
            try
            {
                var course = await repository.GetById(id);
                List<StudentDTO> studentDTOs = new List<StudentDTO>();
                foreach (var student in course.Students)
                {
                    StudentDTO studentDTO = new StudentDTO()
                    {
                        CourseName = course.Name,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth
                    };
                    studentDTOs.Add(studentDTO);
                }

                CourseDTO courseDTO = new CourseDTO()
                {
                    Name = course.Name,
                    Students = studentDTOs
                };

                var payload = new Payload<CourseDTO>() { Data = courseDTO };
                return TypedResults.Ok(payload);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }


        }

    }
}
