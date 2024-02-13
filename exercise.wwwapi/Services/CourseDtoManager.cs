using exercise.wwwapi.DataModels.CourseModels;
using exercise.wwwapi.DataModels.StudentModels;

namespace exercise.wwwapi.Services
{
    public static class CourseDtoManager
    {
        public static CourseWhitoutStudents ConvertRemoveStudents(Course course)
        {
            if (course == null)
                return null;

            return new CourseWhitoutStudents
            {
                Id = course.Id,
                Title = course.Title,
                Starts = course.Starts
            };
        }

        public static OutputCourse Convert(Course course)
        {
            return new OutputCourse
            {
                Id = course.Id,
                Title = course.Title,
                Starts = course.Starts,
                Students = StudentDtoManager.ConvertRemoveCourse(course.Students)
            };
        }

        public static IEnumerable<OutputCourse> Convert(IEnumerable<Course> courses)
        {
            return courses.Select(Convert);
        }

        public static Course Convert(InputCourse inputCourse)
        {
            return new Course
            {
                Title = inputCourse.Title,
                Starts = inputCourse.Starts
            };
        }
    }
}
