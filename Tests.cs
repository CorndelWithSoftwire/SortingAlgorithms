using System;
using System.Linq;
using NUnit.Framework;

namespace SortingAlgorithms
{
  [TestFixture]
  public class Tests
  {
    private static ISortAlgorithm[] Algorithms => new ISortAlgorithm[]
    {
      new SelectionSort(),
      new InsertionSort(),
      new MergeSort()
    };

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void EmptyArray(ISortAlgorithm algorithm)
    {
      var input = new int[0];

      var output = algorithm.Sort(input);

      CollectionAssert.IsEmpty(output);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void SingleElementArray(ISortAlgorithm algorithm)
    {
      var input = new[] {42};

      var output = algorithm.Sort((int[]) input.Clone());

      CollectionAssert.AreEqual(input, output);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void AlreadySortedArray(ISortAlgorithm algorithm)
    {
      var input = new[] {1, 2, 3, 4, 5};

      var output = algorithm.Sort((int[]) input.Clone());

      CollectionAssert.AreEqual(input, output);
    }

    [Test]
    [TestCaseSource(nameof(Algorithms))]
    public void ReverseSortedArray(ISortAlgorithm algorithm)
    {
      var input = new[] {5, 4, 3, 2, 1};

      var output = algorithm.Sort((int[])input.Clone());

      CollectionAssert.AreEqual(input.Reverse(), output);
    }

  }
}