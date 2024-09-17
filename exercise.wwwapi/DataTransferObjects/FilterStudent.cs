using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class FilterStudent : IFilter<Student>
    {
        public Student AssignIdToEntity(IEnumerable<Student> table, Student entity)
        {
            entity.Id = table.Max(x => x.Id) + 1;
            return entity;
        }

        IEnumerable<Student> IFilter<Student>.FilterById(IEnumerable<Student> table, int id)
        {
            return table.Where(x => x.Id == id);
        }
    }
}
