using System;

namespace SortingAlgorithms
{
  public class MergeSort : ISortAlgorithm
  {
    public int[] Sort(int[] input)
    {
      int lengthOfSortedLists = 1;

      while (lengthOfSortedLists < input.Length)
      {
        int leftListStart = 0;

        while (leftListStart < input.Length)
        {
          int rightListStart = leftListStart + lengthOfSortedLists;
          Merge(input, leftListStart, rightListStart, lengthOfSortedLists);

          leftListStart = rightListStart + lengthOfSortedLists;
        }

        lengthOfSortedLists *= 2;
      }

      return input;
    }

    private void Merge(int[] input, int leftListStart, int rightListStart, int lengthOfSortedLists)
    {
      int leftListIndex = leftListStart;
      int rightListIndex = rightListStart;
      int leftListEnd = Math.Min(rightListStart, input.Length);
      int rightListEnd = Math.Min(rightListStart + lengthOfSortedLists, input.Length);
      var working = new int[rightListEnd - leftListStart];
      int workingIndex = 0;

      while (leftListIndex < leftListEnd || rightListIndex < rightListEnd)
      {
        if (leftListIndex == leftListEnd || rightListIndex < rightListEnd && input[rightListIndex] < input[leftListIndex])
        {
          working[workingIndex] = input[rightListIndex];
          rightListIndex++;
        }
        else
        {
          working[workingIndex] = input[leftListIndex];
          leftListIndex++;
        }

        workingIndex++;
      }

      Array.Copy(working, 0, input, leftListStart, working.Length);
    }
  }
}