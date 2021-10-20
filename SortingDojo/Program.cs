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

            var numbers = new List<int>() { 9, 18, -23, 17, 0, 6, -19, 9, 2, -6, 8, 19, -3, 4, 7, -1 };
            Console.WriteLine($"before:\n{string.Join(' ',numbers)}");

            foreach (var sorter in sorters)
            {
                var toSort = new List<int>(numbers);
                sorter.Sort(toSort, out int comparisons, out int switches);
                Console.WriteLine($"after {sorter.GetName()} comparisons:{comparisons} switches:{switches}");
                Console.WriteLine($"{string.Join(' ', toSort)}");
            }
        }
    }
}
