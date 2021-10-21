using SortingDojo.Sorters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortingDojo
{
    static class SortBenchmark
    {
        static Random random = new Random();
        const int minProblemSize = 10;
        const int maxProblemSize = 10000;
        const int problemSizeStep = 100;

        static Dictionary<int, Dictionary<string, double>> resultsTime = new Dictionary<int, Dictionary<string, double>>();
        static Dictionary<int, Dictionary<string, double>> resultsComparisons = new Dictionary<int, Dictionary<string, double>>();
        static Dictionary<int, Dictionary<string, double>> averageWrites = new Dictionary<int, Dictionary<string, double>>();
        public static void Run(IList<ISorter> sorters)
        {
            for (int elements = minProblemSize; elements <= maxProblemSize; elements += problemSizeStep)
            {
                resultsTime[elements] = new Dictionary<string, double>();
                resultsComparisons[elements] = new Dictionary<string, double>();
                averageWrites[elements] = new Dictionary<string, double>();

                int repeats = 300000 / elements;
                List<List<int>> lists = GenerateRandomLists(elements, repeats);

                Console.WriteLine($"Problem size: {elements}");

                foreach (var sorter in sorters)
                {
                    TestSorter(sorter, lists);
                }
            }

            PrintCsv();

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
            double averageWrites = 0.0;
            double averageTime;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var list in lists)
            {
                var toSort = new List<int>(list);
                sorter.Sort(toSort, out int comparisons, out int writes);
                averageComparisons += comparisons;
                averageWrites += writes;
            }
            stopwatch.Stop();

            averageTime = (double)stopwatch.ElapsedMilliseconds * 1000.0 / lists.Count;
            averageComparisons /= lists.Count;
            averageWrites /= lists.Count;

            resultsTime[lists[0].Count][sorter.GetName()] = averageTime;
            resultsComparisons[lists[0].Count][sorter.GetName()] = averageComparisons;
            SortBenchmark.averageWrites[lists[0].Count][sorter.GetName()] = averageWrites;

            Console.WriteLine($"\tSorter: {sorter.GetName()} Time: {averageTime:F3}us Comparisons: {averageComparisons:F3} Writes: {averageWrites:F3}");
        }

        private static void PrintCsv()
        {
            Console.WriteLine("Average times");
            StringBuilder sb = new StringBuilder();
            sb.Append('n');
            foreach (var key in resultsTime[minProblemSize].Keys)
            {
                sb.Append($",{key}");
            }
            Console.WriteLine(sb.ToString());

            foreach (var n in resultsTime.Keys)
            {
                sb.Clear();
                sb.Append($"{n}");
                foreach (var algorithm in resultsTime[n].Keys)
                {
                    sb.Append($",{resultsTime[n][algorithm]:F3}");
                }
                Console.WriteLine(sb.ToString());
            }

            Console.WriteLine("Average comparisons");
            sb.Clear();
            sb.Append('n');
            foreach (var key in resultsComparisons[minProblemSize].Keys)
            {
                sb.Append($",{key}");
            }
            Console.WriteLine(sb.ToString());

            foreach (var n in resultsComparisons.Keys)
            {
                sb.Clear();
                sb.Append($"{n}");
                foreach (var algorithm in resultsComparisons[n].Keys)
                {
                    sb.Append($",{resultsComparisons[n][algorithm]:F3}");
                }
                Console.WriteLine(sb.ToString());
            }

            Console.WriteLine("Average writes");
            sb.Clear();
            sb.Append('n');
            foreach (var key in averageWrites[minProblemSize].Keys)
            {
                sb.Append($",{key}");
            }
            Console.WriteLine(sb.ToString());

            foreach (var n in averageWrites.Keys)
            {
                sb.Clear();
                sb.Append($"{n}");
                foreach (var algorithm in averageWrites[n].Keys)
                {
                    sb.Append($",{averageWrites[n][algorithm]:F3}");
                }
                Console.WriteLine(sb.ToString());
            }
        }

    }
}
