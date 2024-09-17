using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class FilterCourse : IFilter<Course>
    {
        public Course AssignIdToEntity(IEnumerable<Course> table, Course entity)
        {
            entity.Id = table.Max(x => x.Id) + 1;
            return entity;
        }

        public Course AssignNewData(DataContext db, int id, string stringOne, string stringTwo, DateTime date)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Course> IFilter<Course>.FilterById(IEnumerable<Course> table, int id)
        {
            return table.Where(x => x.Id == id);
        }
    }
}
