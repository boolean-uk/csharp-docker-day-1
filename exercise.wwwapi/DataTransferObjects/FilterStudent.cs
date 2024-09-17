using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Xml.Linq;

namespace exercise.wwwapi.DataTransferObjects
{
    public class FilterStudent : IFilter<Student>
    {
        public Student AssignIdToEntity(IEnumerable<Student> table, Student entity)
        {
            entity.Id = table.Max(x => x.Id) + 1;
            return entity;
        }

        public Student AssignNewData(DataContext db, int id, string stringOne, string stringTwo, DateTime date)
        {
            Student student = new Student() { Id = id, FirstName = stringOne, LastName = stringTwo, DoB = date };
            db.Students.Where(x => x.Id == id).ExecuteUpdate(x => x.SetProperty(z => z.FirstName, stringOne).SetProperty(x => x.LastName, stringTwo).SetProperty(x => x.DoB, date));
            return student;
        }

        IEnumerable<Student> IFilter<Student>.FilterById(IEnumerable<Student> table, int id)
        {
            return table.Where(x => x.Id == id);
        }
    }
}
