using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortingAlgorithms
{
  class Program
  {
    static void Main()
    {
      new Program().Run();
    }

    private void Run()
    {
      Console.WriteLine("Selection Sort should take four times as long if you double the input length");
      TimeSort(new SelectionSort(), PseudoRandomNumbers.Take(20000).ToArray());
      TimeSort(new SelectionSort(), PseudoRandomNumbers.Take(40000).ToArray());
      Console.WriteLine();

      Console.WriteLine("Insertion Sort should take getting on for four times as long if you double the input length");
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(20000).ToArray());
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(40000).ToArray());
      Console.WriteLine();

      Console.WriteLine("Insertion Sort should only take twice as long if you double the input length but the inputs are sorted");
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(200000).OrderBy(n => n).ToArray());
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(400000).OrderBy(n => n).ToArray());
      Console.WriteLine();

      Console.WriteLine(
        "Insertion Sort should take four times as long if you double the input length and the inputs are reverse-sorted");
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(20000).OrderByDescending(n => n).ToArray());
      TimeSort(new InsertionSort(), PseudoRandomNumbers.Take(40000).OrderByDescending(n => n).ToArray());
      Console.WriteLine();

      Console.WriteLine("Merge Sort shouldn't take much more than twice as long if you double the input length");
      TimeSort(new MergeSort(), PseudoRandomNumbers.Take(200000).ToArray());
      TimeSort(new MergeSort(), PseudoRandomNumbers.Take(400000).ToArray());
      Console.WriteLine();

      Console.WriteLine("Merge Sort shouldn't take much more than 100 times as long if you multiply the input length by 100");
      TimeSort(new MergeSort(), PseudoRandomNumbers.Take(200000).ToArray());
      TimeSort(new MergeSort(), PseudoRandomNumbers.Take(200000 * 100).ToArray());
      Console.WriteLine();

      Console.ReadLine();
    }

    private void TimeSort(ISortAlgorithm sortAlgorithm, int[] input)
    {
      var stopwatch = new Stopwatch();
      stopwatch.Start();
      sortAlgorithm.Sort(input);
      stopwatch.Stop();

      Console.WriteLine($"{sortAlgorithm.GetType().Name} took {stopwatch.ElapsedMilliseconds}ms to sort {input.Length} numbers");
    }

    public IEnumerable<int> PseudoRandomNumbers
    {
      get
      {
        var random = new Random(RandomNumberSeed); // Fixed seed so the numbers are the same every time on this run

        while (true)
        {
          yield return random.Next();
        }
      }
    }

    public static int RandomNumberSeed = new Random().Next();
  }
}
