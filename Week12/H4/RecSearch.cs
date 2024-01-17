public static class RecSearch
{
    // public entrypoint
    public static int BinarySearch(int[] arr, int value)
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }
    // searching for value, assuming first is smallest and last is biggest
    private static int BinarySearch(int[] arr, int value, int first, int last)
    {
        // checks if first is less than last
        if(first <= last)
        {
            // if first is more than val, it isn't in the array, so return -1
            if(arr[first] > value)
                return -1;
            // else, go to the average
            int index = first + ((last - first) / 2);
            Console.WriteLine($"{index}, {last}");
            // if this index matches the value, return the index
            if(arr[index] == value)
                return index;
            // otherwise, return the function with the half of the array the value should be in
            else if(arr[index] < value)
            {
                return BinarySearch(arr, value, index + 1, last);
            }
            else if(arr[index] > value)
                return BinarySearch(arr, value, first, index);
        }
        return -1;
    }
}
