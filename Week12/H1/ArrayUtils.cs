public static class ArrayUtils
{
    // public entrypoint to the function
    public static int FindMinimum(int[] arr)
    {
        return RecMinimum(arr, arr.Length - 1);
    }

    private static int RecMinimum(int[] array, int i)
    {
        // checks for every number in the array whether the number is the minimum against the previous minimum
        if (i > 0)
        {
            int minimum = RecMinimum(array, i - 1);
            return Math.Min(array[i], minimum);
        }
        return array[i];
    }
}
