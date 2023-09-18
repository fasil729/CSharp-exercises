using System.Collections.Generic;
using System.Linq;

class StudentList<T> : List<T> where T : Student
{
    public IEnumerable<T> Search(string searchQuery)
    {
        return this.Where(s =>
            s.Name.Equals(searchQuery, System.StringComparison.OrdinalIgnoreCase) ||
            s.RollNumber.Equals(searchQuery, System.StringComparison.OrdinalIgnoreCase));
    }
}