using Newtonsoft.Json;
public static class ContainerManager
{
    public static Queue<Container> selectedForInspection = new();
    public static Stack<Container> underReview = new();
    // reads all jsons in the path and marks some of them for inspection
    public static void Start(string Path)
    {
        List<Container> containers;
        foreach(string file in Directory.EnumerateFiles(Path))
        {
            containers = ProcessManifest(file);
            MarkForInspection(containers, x => x.Origin == "COL" && x.Categories.Contains("Fruits"));
        }
        InspectContainers();
    }
    // reads out the json given
    public static List<Container> ProcessManifest(string file)
    {
        string FileContent = File.ReadAllText(@file);
        List<Container> ContainerList = JsonConvert.DeserializeObject<List<Container>>(FileContent);
        return ContainerList;
    }
    // return all containers from the origin given
    public static List<Container> SearchByOrigin(List<Container> containers, string origin)
    {
        List<Container> returnContainers = containers.FindAll(x => x.Origin == origin);
        return returnContainers;
    }
    // returns the heaviest container
    public static Container SearchForHeaviest(List<Container> containers)
    {
        return containers.MaxBy(x => x.Weight);
    }
    // marks any containers that succeed the lambda for inspection, the rest are clear
    public static void MarkForInspection(List<Container> containers, Func<Container, bool>? lambda)
    {
        int num = 0;
        foreach(Container container in containers)
        {
            if (lambda == null || !lambda(container)) { container.Status = (ContainerStatus)9; }
            else 
            {
                num += 1;
                container.Status = (ContainerStatus)1;
                selectedForInspection.Enqueue(container);
            }
            ContainerLogger.Log(container);
        }
        Console.WriteLine($"Number of containers selected for inspection: {num}");
    }
    // inspects all containers that are marked for inspection, if they succeed they are pushed to under review,
    // otherwise they are logged using the logger
    public static void InspectContainers()
    {
        int currLength = selectedForInspection.Count;
        for(int i = 0; i < currLength; i++)
        {
            Container container = selectedForInspection.Dequeue();
            if(container.ActualWeight > container.Weight * 1.1)
            {
                container.Status = ContainerStatus.UnderReview;
                underReview.Push(container);
                ContainerLogger.Log(container);
            }
            else if(!(container.ActualWeight > container.Weight * 1.1))
            {
                container.Status = ContainerStatus.ApprovedAfterInspection;
                ContainerLogger.Log(container);
            }
        }
    }
}
