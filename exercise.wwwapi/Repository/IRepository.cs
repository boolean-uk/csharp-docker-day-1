using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T>
    {
        Task<Student> AddNewObject(Student newStudent);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<Student> Update(int id, Student updateStudent);
    }

}
