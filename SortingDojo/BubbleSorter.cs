using System;
using System.Collections.Generic;

namespace SortingDojo
{
    class BubbleSorter : ISorter
    {
        readonly string name = "Bubblesort";
        public void Sort(IList<int> list, out int comparisons, out int switches)
        {
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
                    }
                }

            } while (changes);

            comparisons = 0;
            switches = 0;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
