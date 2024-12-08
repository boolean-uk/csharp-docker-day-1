using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
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
            var courses = app.MapGroup("courses");
            courses.MapGet("/", GetCourses);
            courses.MapGet("/{id}", GetACourse);
            courses.MapPost("/", CreateCourse);
            courses.MapDelete("/{id}", DeleteCourse);
            courses.MapPut("/{id}", UpdateCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository)
        {
            try
            {
                var results = await repository.GetAll();

                List<GetCourseDTO> cs = new List<GetCourseDTO>();

                foreach (var course in results)
                {
                    List<GetStudentDTO> students = new List<GetStudentDTO>();

                    foreach (var student in course.Students)
                    {
                        GetStudentDTO studentDTO = new GetStudentDTO()
                        {
                            Name = $"{student.FirstName} {student.LastName}",
                            DateOfBirth = student.DateOfBirth,
                            CourseTitle = course.CourseTitle,
                            AverageGrade = student.AverageGrade,
                        };

                        students.Add(studentDTO);
                    }

                    GetCourseDTO courseDTO = new GetCourseDTO()
                    {
                        CourseTitle = course.CourseTitle,
                        Students = students
                    };

                    cs.Add(courseDTO);
                }

                var payload = new Payload<IEnumerable<GetCourseDTO>>() { Data = cs };
                return TypedResults.Ok(payload);

            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetACourse(IRepository<Course> repository, int id)
        {
            try
            {
                var result = await repository.GetById(id);

                List<GetStudentDTO> students = new List<GetStudentDTO>();

                foreach (var student in result.Students)
                {
                    GetStudentDTO studentDTO = new GetStudentDTO()
                    {
                        Name = $"{student.FirstName} {student.LastName}",
                        DateOfBirth = student.DateOfBirth,
                        CourseTitle = result.CourseTitle,
                        AverageGrade = student.AverageGrade,
                    };

                    students.Add(studentDTO);
                }

                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    CourseTitle = result.CourseTitle,
                    Students = students
                };

                var payload = new Payload<GetCourseDTO>() { Data = courseDTO };
                return TypedResults.Ok(payload);
            }
            catch (Exception)
            {
                return TypedResults.NotFound($"Course with id {id} not found");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCourse(IRepository<Course> repository, string title)
        {
            try
            {
                var newCourse = new Course() { CourseTitle = title };


                

                var result = await repository.Create(newCourse);

                var target = await repository.GetById(result.Id);

                List<GetStudentDTO> students = new List<GetStudentDTO>();

                foreach (var student in result.Students)
                {
                    GetStudentDTO studentDTO = new GetStudentDTO()
                    {
                        Name = $"{student.FirstName} {student.LastName}",
                        DateOfBirth = student.DateOfBirth,
                        CourseTitle = result.CourseTitle,
                        AverageGrade = student.AverageGrade,
                    };

                    students.Add(studentDTO);
                }

                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    CourseTitle = result.CourseTitle,
                    Students = students
                };

                var payload = new Payload<GetCourseDTO>() { Data = courseDTO };
                var path = $"courses/{result.Id}";
                return TypedResults.Created(path, payload);

            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            try
            {
                await repository.Delete(id);
                return TypedResults.Ok($"Course with id {id} deleted!");
            }
            catch (Exception)
            {
                return TypedResults.NotFound($"Course with id {id} not found");
            }
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, string title)
        {
            try
            {
                var target = await repository.GetById(id);

                if (target == null)
                {
                    return TypedResults.NotFound($"Course with id {id} not found");
                }

                target.CourseTitle = title;

                var result = await repository.Update(target);

                List<GetStudentDTO> students = new List<GetStudentDTO>();

                foreach (var student in result.Students)
                {
                    GetStudentDTO studentDTO = new GetStudentDTO()
                    {
                        Name = $"{student.FirstName} {student.LastName}",
                        DateOfBirth = student.DateOfBirth,
                        CourseTitle = result.CourseTitle,
                        AverageGrade = student.AverageGrade,
                    };

                    students.Add(studentDTO);
                }

                GetCourseDTO courseDTO = new GetCourseDTO()
                {
                    CourseTitle = result.CourseTitle,
                    Students = students
                };

                var payload = new Payload<GetCourseDTO>() { Data = courseDTO };
                var path = $"courses/{result.Id}";
                return TypedResults.Created(path, payload);

            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}

