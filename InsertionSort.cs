namespace SortingAlgorithms
{
  public class InsertionSort : ISortAlgorithm
  {
    public int[] Sort(int[] input)
    {
      var topOfSortedList = 0;

      while (topOfSortedList < input.Length - 1)
      {
        var elementToInsert = topOfSortedList + 1;

        while (elementToInsert > 0 && input[elementToInsert - 1] > input[elementToInsert])
        {
          var temp = input[elementToInsert];
          input[elementToInsert] = input[elementToInsert - 1];
          input[elementToInsert - 1] = temp;

          elementToInsert--;
        }

        topOfSortedList++;
      }

      return input;
    }
  }
}