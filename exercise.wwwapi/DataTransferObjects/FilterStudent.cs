using exercise.wwwapi.DataModels;
using System.Runtime.InteropServices;

namespace exercise.wwwapi.DataTransferObjects
{
    public class FilterStudent : IFilter<Student>
    {

        IEnumerable<Student> IFilter<Student>.FilterById(IEnumerable<Student> table, int id)
        {
            return table.Where(x => x.Id == id);
        }
    }
}
