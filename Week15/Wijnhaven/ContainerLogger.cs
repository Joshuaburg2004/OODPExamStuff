public static class ContainerLogger
{
    public static Dictionary<string, Container> containerLog = new();
    public static void Log(Container container) { containerLog[container.Code] = container; }
    // prints all containers in the value
    public static void Print()
    {
        foreach(Container container in containerLog.Values) { Console.WriteLine(container); }
    }
    public static void GetAverageWeightDeviation(ContainerStatus status)
    {
        List<Container> containers = containerLog.Values.ToList();
        // finds all of a certain status
        List<Container> filteredContainers = containers.FindAll(x => x.Status == status);
        var deviations = filteredContainers.Select(x => Convert.ToInt32(x.ActualWeight - x.Weight)).ToList();
        // turns all deviations positive
        deviations = deviations.ConvertAll(x =>
        {
            if (x < 0) { return -x; }
            return x;
        });
        // prints the correct information
        Console.WriteLine($"Average Deviation from containers with status '{status}': {Convert.ToInt32(deviations.Average())}");
    }
    public static void GetDistinctCategories(ContainerStatus status)
    {
        List<Container> containers = containerLog.Values.ToList();
        // find all containers with a status that is specified
        List<Container> filteredContainers = containers.FindAll(x => x.Status == status);
        // proper output shenanigens
        Console.Write($"Distinct categories from containers with status '{status}': [");
        string output = "";
        // gets all distinct categories using both selectMany and Distinct
        foreach (string category in filteredContainers.SelectMany(x => x.Categories).Distinct()) 
        {
            output += $"{category},";
        }
        // removes final character from output
        output = output.Remove(output.Length - 1, 1);
        Console.Write($"{output}]");
    }
}
