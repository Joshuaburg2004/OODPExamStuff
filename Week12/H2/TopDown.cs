public static class TopDown
{
    // display without format
    public static void Display<T>(Item<T> item) => Display(item, "");
    // display with a format
    public static void Display<T>(Item<T> item, string format)
    {
        if (item == null)
        {
            Console.WriteLine("None");
            return;
        }

        Console.WriteLine($"{format} {item.Value}");
        if (item.SubItems == null)
            return;

        item.SubItems.ForEach(sub => Display(sub, format + "---"));
    }
    // looks if the item given equals the key, if so returns it. if not, calls itself on the subitems until there
    // isn't anything left to check. returns null if nothing matches the key
    public static Item<T>? Find<T>(Item<T>? item, T? key)
    {
        if (item.Value.Equals(key))
            return item;
        if(item.SubItems is not null)
        {
            foreach(Item<T>? i in item.SubItems!)
            {
                Item<T>? items = Find(i, key);
                if(items is not null)
                    return items;
            }
        }
        
        return null;
    }
}
