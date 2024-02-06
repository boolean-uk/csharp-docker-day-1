using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> CreateStudent(CreateNewStudentPayload createData);

        Task<Student> UpdateStudent(int id, UpdateStudentPayload updateData);

        Task<Student> DeleteStudent(int id);
        //Task<IEnumerable<Course>> GetCourses();

        

        //post

        //delete
    }

}
