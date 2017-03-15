namespace SortingAlgorithms
{
  public interface ISortAlgorithm
  {
    // Sort the input array into numerical order
    // Note that the input may be modified by the algorithm - 
    //   the return value may or may not point to the same object as the input
    int[] Sort(int[] input);
  }
}