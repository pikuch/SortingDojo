using System.Collections.Generic;

namespace SortingDojo.Sorters
{
    class BubbleSorter : ISorter
    {
        public string GetName() => "Bubblesort";
        public void Sort(IList<int> list, out int comparisons, out int writes)
        {
            comparisons = 0;
            writes = 0;

            bool changes;
            do
            {
                changes = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        changes = true;
                        (list[i], list[i + 1]) = (list[i + 1], list[i]);
                        comparisons++;
                        writes+=2;
                    }
                }
            } while (changes);
        }
    }
}
