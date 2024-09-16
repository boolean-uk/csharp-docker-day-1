using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.ViewModels;

namespace exercise.wwwapi.Extensions
{
    public static class CourseExtensions
    {

        public static CourseDTO ToDTO(this Course course)
        {
            return new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                StartDate = course.StartDate.ToString("yyyy-MM-dd"),
            };
        }
        public static void Update(this Course course, CourseUpdate courseUpdate)
        {
            if(!string.IsNullOrEmpty(courseUpdate.Title)) course.Title = courseUpdate.Title;
            if(!string.IsNullOrEmpty(courseUpdate.StartDate)) course.StartDate = DateTime.Parse(courseUpdate.StartDate).ToUniversalTime();
        }
        public static Course ToCourse(this CoursePost coursePost)
        {
            return new Course
            {
                Title = coursePost.Title,
                StartDate = DateTime.Parse(coursePost.StartDate).ToUniversalTime()
            };
        }
    }
}
