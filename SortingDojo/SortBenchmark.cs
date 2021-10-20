using SortingDojo.Sorters;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortingDojo
{
    static class SortBenchmark
    {
        static Random random = new Random();
        public static void Run(IList<ISorter> sorters)
        {
            for (int problemSizePower = 4; problemSizePower <= 12; problemSizePower++)
            {
                int elements = 1 << problemSizePower;
                int repeats = (int)Math.Pow(3, 16 - problemSizePower);
                List<List<int>> lists = GenerateRandomLists(elements, repeats);

                Console.WriteLine($"\tProblem size: {elements}");

                foreach (var sorter in sorters)
                {
                    TestSorter(sorter, lists);
                }
            }
        }

        private static List<List<int>> GenerateRandomLists(int elements, int repeats)
        {
            var output = new List<List<int>>();
            for (int r = 0; r < repeats; r++)
            {
                var newList = new List<int>();
                for (int i = 0; i < elements; i++)
                {
                    newList.Add(random.Next());
                }
                output.Add(newList);
            }
            return output;
        }

        private static void TestSorter(ISorter sorter, List<List<int>> lists)
        {
            double averageComparisons = 0.0;
            double averageSwitches = 0.0;
            double averageTime;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var list in lists)
            {
                var toSort = new List<int>(list);
                sorter.Sort(toSort, out int comparisons, out int switches);
                averageComparisons += comparisons;
                averageSwitches += switches;
            }
            stopwatch.Stop();

            averageTime = (double)stopwatch.ElapsedMilliseconds * 1000.0 / lists.Count;
            averageComparisons /= lists.Count;
            averageSwitches /= lists.Count;

            Console.WriteLine($"Sorter: {sorter.GetName()} Time: {averageTime:N3}us Comparisons: {averageComparisons:N2} Switches: {averageSwitches:N2}");
        }
    }
}
