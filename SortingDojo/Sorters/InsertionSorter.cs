using System.Collections.Generic;

namespace SortingDojo.Sorters
{
    class InsertionSorter : ISorter
    {
        public string GetName() => "Insertionsort";
        public void Sort(IList<int> list, out int comparisons, out int writes)
        {
            comparisons = 0;
            writes = 0;

            for (int edge = 1; edge < list.Count; edge++)
            {
                var currentValue = list[edge];
                var index = edge - 1;
                while (index >= 0 && list[index] > currentValue)
                {
                    list[index + 1] = list[index];
                    index--;
                    comparisons++;
                    writes++;
                }
                list[index + 1] = currentValue;
                writes++;
            }
        }
    }
}
