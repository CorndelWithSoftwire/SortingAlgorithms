namespace SortingAlgorithms
{
  public class SelectionSort : ISortAlgorithm
  {
    public int[] Sort(int[] input)
    {
      int topOfSortedList = -1;

      while (topOfSortedList < input.Length - 1)
      {
        int smallestElementIndex = topOfSortedList + 1;

        for (int i = topOfSortedList + 2; i < input.Length; i++)
        {
          if (input[i] < input[smallestElementIndex])
          {
            smallestElementIndex = i;
          }
        }

        var temp = input[topOfSortedList + 1];
        input[topOfSortedList + 1] = input[smallestElementIndex];
        input[smallestElementIndex] = temp;

        topOfSortedList = topOfSortedList + 1;
      }

      return input;
    }
  }
}