using System.Collections.Generic;

namespace SortingDojo
{
    class InsertionSorter : ISorter
    {
        public string GetName() => "Insertionsort";
        public void Sort(IList<int> list, out int comparisons, out int switches)
        {
            comparisons = 0;
            switches = 0;

            for (int edge = 1; edge < list.Count; edge++)
            {
                var currentValue = list[edge];
                var index = edge - 1;
                while (index >= 0 && list[index] > currentValue)
                {
                    list[index + 1] = list[index];
                    index--;
                    comparisons++;
                    switches++;
                }
                list[index + 1] = currentValue;
                switches++;
            }
        }
    }
}
