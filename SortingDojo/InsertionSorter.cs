using System.Collections.Generic;

namespace SortingDojo
{
    class InsertionSorter : ISorter
    {
        readonly string name = "Insertionsort";
        public void Sort(IList<int> list, out int comparisons, out int switches)
        {
            for (int edge = 1; edge < list.Count; edge++)
            {
                var currentValue = list[edge];
                var index = edge - 1;
                while (index >= 0 && list[index] > currentValue)
                {
                    list[index + 1] = list[index];
                    index--;
                }
                list[index + 1] = currentValue;
            }
            comparisons = 0;
            switches = 0;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
