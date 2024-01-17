public static class HOF
{
    // if the lambda matches the item, it is added to the list. Otherwise, goes through the rest.
    public static List<T> Filter<T>(List<T> list, Func<T, bool> lambda)
    {
        List<T> returnList = new();
        foreach(T item in list)
        {
            if(lambda(item))
            {
                returnList.Add(item);
            }
        }
        return returnList;
    }
}
