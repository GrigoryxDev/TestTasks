using System;
using System.Linq;

namespace WordsDiagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputValues = Console.ReadLine().Split(' ');

            // array sorting and key value searching
            var orderedValues = inputValues.GroupBy(v => v)
                .OrderBy(o => o.Count())
                .ThenBy(o => o.Key)
                .SelectMany(o => o);

            int maxCount = orderedValues.GroupBy(g => g)
                .OrderByDescending(o => o.Count())
                .First()
                .Count();

            string wordMaxLength = orderedValues.OrderByDescending(l => l.Length)
                .First();

            int dotsNumber = 0;

            // Calculation the frequency every unique element in sorted array 
            foreach (var item in orderedValues.Distinct().ToArray())
            {
                var count = orderedValues.Where(c => c == item).Count();
                if (count != maxCount)
                {
                    dotsNumber = (int)Math.Round((double)count * (double)10 / (double)maxCount);
                    if (dotsNumber == 10)
                    {
                        dotsNumber -= 1;
                    }
                }
                else if (count == maxCount)
                {
                    dotsNumber = 10;
                }
                Console.WriteLine($"{new string('_', wordMaxLength.Length - item.Length)}{item} {new string('.', dotsNumber)}");
            }
        }
    }
}
