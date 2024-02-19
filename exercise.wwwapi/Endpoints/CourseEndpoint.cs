using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.DTOs;
using exercise.wwwapi.Posts___Puts;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
            students.MapPost("/", CreateCourses);
            students.MapPut("/", UpdateCourse);
            students.MapDelete("/", DeleteCourse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCourses(IRepository<Course> repository, IRepository<Student> studrepo)
        {
            var studs = await studrepo.GetAll();
            var results = await repository.GetAll();

            List<CourseDTO> courses = new List<CourseDTO>();
            
            foreach(var course in results)
            {
                courses.Add(CreateCourseDTO(course));
            }

            Payload<IEnumerable<CourseDTO>> payload = new Payload<IEnumerable<CourseDTO>>();
            payload.data = courses;
            return TypedResults.Ok(courses);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateCourses(IRepository<Course> repository, CoursePostPut newCourse)
        {
            var all = await repository.GetAll();
            //var cStudents = await studrepo.GetAll();
            //This in case i want to add all students to the IColl list.

            var theCourse = new Course()
            {
                CourseName = newCourse.CourseName,
                AvgGrade = newCourse.AvgGrade,
                StartOfCourse = newCourse.StartDate
            };
            

            CourseDTO courseDTO = CreateCourseDTO(await repository.Create(theCourse));

            Payload<CourseDTO> payload = new Payload<CourseDTO>();
            payload.data = courseDTO;
            return TypedResults.Ok(payload);
                
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateCourse(IRepository<Course> repository, int id, CoursePostPut courseUpdate)
        {
            var entity = await repository.GetById(id);
            if (entity == null) {
                return TypedResults.NotFound(id);
            }

            entity.StartOfCourse = courseUpdate.StartDate != null ? courseUpdate.StartDate : entity.StartOfCourse;
            entity.CourseName = courseUpdate.CourseName != null ? courseUpdate.CourseName : entity.CourseName;
            entity.AvgGrade = courseUpdate.AvgGrade != null ? courseUpdate.AvgGrade : entity.AvgGrade;

            var result = await repository.Update(entity);

            Payload<CourseDTO> payload = new Payload<CourseDTO>();
            payload.data = CreateCourseDTO(result);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteCourse(IRepository<Course> repository, int id)
        {
            var course = await repository.GetById(id);
            if (course == null)
            {
                return TypedResults.NotFound(id);
            }

            var result = await repository.Delete(id);
            Payload<CourseDTO> payload = new Payload<CourseDTO>();
            payload.data = CreateCourseDTO(result);
            return TypedResults.Ok(payload);
        }




        static CourseDTO CreateCourseDTO(Course course)
        {
            var students = new List<StudentCourseDTO>();
            foreach(var student in course.Students)
            {
                students.Add(new StudentCourseDTO()
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                });
            }
            return new CourseDTO
            {
                CourseId = course.Id,
                CourseName = course.CourseName,
                AvgGrade = course.AvgGrade,
                StartDate = course.StartOfCourse,
                Students = students.OrderBy(s => s.StudentId).ToList() 
            };
        }
    }
}
