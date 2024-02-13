using exercise.wwwapi.DataModels.CourseModels;
using exercise.wwwapi.DataModels.StudentModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

            students.MapGet("", GetAll);
            students.MapGet("{id}", Get);
            students.MapPost("", Create);
            students.MapPut("{id}", Update);
            students.MapDelete("{id}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Course> repository)
        {
            IEnumerable<Course> results = await repository.Get();

            IEnumerable<OutputCourse> outputCourses = CourseDtoManager.Convert(results);
            Payload<IEnumerable<OutputCourse>> payload = new Payload<IEnumerable<OutputCourse>>() { data = outputCourses };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Get(IRepository<Course> repository, int id)
        {
            Course? result = await repository.Get(id);

            if (result == null)
                return TypedResults.NotFound();

            OutputCourse outputCourse = CourseDtoManager.Convert(result);
            Payload<OutputCourse> payload = new Payload<OutputCourse>() { data = outputCourse };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Create(IRepository<Course> courseRepository, IRepository<Student> studentRepository, InputCourse inputCourse)
        {
            List<Student> students = new List<Student>();
            foreach (int studenId in inputCourse.StudentIds)
            {
                Student? student = await studentRepository.Get(studenId);
                if (student == null)
                    return TypedResults.NotFound($"Student with id {studenId} not found");

                students.Add(student);
            }

            Course course = new Course
            {
                Title = inputCourse.Title,
                Starts = inputCourse.Starts,
                Students = students
            };

            Course result = await courseRepository.Create(course);

            OutputCourse outputCourse = CourseDtoManager.Convert(result);
            Payload<OutputCourse> payload = new Payload<OutputCourse>() { data = outputCourse };
            return TypedResults.Created("url", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Update(int id, IRepository<Course> courseRepository, IRepository<Student> studentRepository,  InputCourse inputCourse)
        {
            Course? course = await courseRepository.Get(id);
            if (course == null)
                return TypedResults.NotFound();

            List<Student> students = new List<Student>();
            foreach (int studenId in inputCourse.StudentIds)
            {
                Student? student = await studentRepository.Get(studenId);
                if (student == null)
                    return TypedResults.NotFound($"Student with id {studenId} not found");

                students.Add(student);
            }

            course.Title = inputCourse.Title;
            course.Starts = inputCourse.Starts;
            course.Students = students;

            Course result = await courseRepository.Update(course);

            OutputCourse outputCourse = CourseDtoManager.Convert(result);
            Payload<OutputCourse> payload = new Payload<OutputCourse>() { data = outputCourse };
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Course> repository, int id)
        {
            // Fetch the existing course from the database
            Course? existingCourse = await repository.Get(id);
            if (existingCourse == null)
                return TypedResults.NotFound();

            // Create a copy of the existing course
            Course courseCopy = new Course
            {
                Id = existingCourse.Id,
                Title = existingCourse.Title,
                Starts = existingCourse.Starts,
                Students = existingCourse.Students != null ? new List<Student>(existingCourse.Students) : null
            };

            // Delete the existing course
            await repository.Delete(id);

            // Convert the copy of the course to an OutputCourse and return it
            OutputCourse outputCourse = CourseDtoManager.Convert(courseCopy);
            var payload = new Payload<OutputCourse>() { data = outputCourse };
            return TypedResults.Ok(payload);
        }
    }
}
