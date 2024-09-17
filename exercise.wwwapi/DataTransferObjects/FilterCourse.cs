using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class FilterCourse : IFilter<Course>
    {

        IEnumerable<Course> IFilter<Course>.FilterById(IEnumerable<Course> table, int id)
        {
            return table.Where(x => x.Id == id);
        }
    }
}
