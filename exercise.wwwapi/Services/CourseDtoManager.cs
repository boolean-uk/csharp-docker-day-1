using exercise.wwwapi.DataModels.CourseModels;

namespace exercise.wwwapi.Services
{
    public static class CourseDtoManager
    {
        public static CourseWhitoutStudents ConvertRemoveStudents(Course course)
        {
            // TODO: Fix something here
            if (course == null)
                return null;

            return new CourseWhitoutStudents
            {
                Id = course.Id,
                Title = course.Title,
                Starts = course.Starts
            };
        }
    }
}
