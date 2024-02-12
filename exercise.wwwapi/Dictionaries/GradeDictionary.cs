using System.Collections.Generic;

namespace exercise.wwwapi.Dictionaries
{
    public static class GradeDictionary
    {
        public static readonly Dictionary<char, int> Grades = new Dictionary<char, int>
        {
            { 'A', 4 },
            { 'B', 3 },
            { 'C', 2 },
            { 'D', 1 },
            { 'F', 0 }
        };
    }
}
