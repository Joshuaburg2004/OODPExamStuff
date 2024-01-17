// update on previous HOF, looks to loop recursively to find the answer
public static class HOF
{
    public static T[] Filter<T>(T[] array, Func<T, bool> predicate)
    {
        return FilterRecursive(array, predicate, 0);
    }

    private static T[] FilterRecursive<T>(T[] array, Func<T, bool> predicate, int index)
    {
        // if the index is to large, return an empty array
        if (index >= array.Length)
        {
            return Array.Empty<T>();
        }
        // otherwise, take the output from the function
        T[] filtered = FilterRecursive(array, predicate, index + 1);
        // check if it matches the predicate
        if (predicate(array[index]))
        {
            // if so, make a new array
            T[] newArray = new T[filtered.Length + 1];
            // make the first item the most recent find
            newArray[0] = array[index];
            // copy the old array into the remaining slots
            Array.Copy(filtered, 0, newArray, 1, filtered.Length);
            // return the new array
            return newArray;
        }
        else
        {
            return filtered;
        }
    }
}
