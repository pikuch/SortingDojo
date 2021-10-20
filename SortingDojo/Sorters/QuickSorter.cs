using System.Collections.Generic;

namespace SortingDojo.Sorters
{
    class QuickSorter : ISorter
    {
        public string GetName() => "Quicksort";
        private int comparisonCounter;
        private int switchCounter;

        public void Sort(IList<int> list, out int comparisons, out int switches)
        {
            comparisonCounter = 0;
            switchCounter = 0;
            Qsort(list, 0, list.Count - 1);
            comparisons = comparisonCounter;
            switches = switchCounter;
        }

        private void Qsort(IList<int> list, int low, int high)
        {
            if (low < high)
            {
                int divisionPoint = DivideAndSort(list, low, high);
                Qsort(list, low, divisionPoint - 1);
                Qsort(list, divisionPoint + 1, high);
            }
        }

        private int DivideAndSort(IList<int> list, int low, int high)
        {
            int dividerIndex = low + (high - low) / 2;
            int dividerValue = list[dividerIndex];
            MakeSwitch(list, dividerIndex, high);
            
            int divisionPoint = low;
            for (int index = low; index < high; index++)
            {
                if (list[index] < dividerValue)
                {
                    MakeSwitch(list, index, divisionPoint);
                    divisionPoint++;
                    comparisonCounter++;
                }
            }

            MakeSwitch(list, divisionPoint, high);
            return divisionPoint;
        }

        private void MakeSwitch(IList<int> list, int index1, int index2)
        {
            if (index1 != index2)
            {
                (list[index1], list[index2]) = (list[index2], list[index1]);
                switchCounter++;
            }
        }
    }
}
