using System.Collections.Generic;

namespace SortingDojo.Sorters
{
    public interface ISorter
    {
        string GetName();
        void Sort(IList<int> list, out int comparisons, out int switches);
    }
}
