using SortingDojo.Sorters;
using System;
using System.Collections.Generic;

namespace SortingDojo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISorter> sorters = new List<ISorter>
            {
                new BubbleSorter(),
                new InsertionSorter(),
                new QuickSorter()
            };

            SortBenchmark.Run(sorters);

        }
    }
}
