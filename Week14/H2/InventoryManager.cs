using Newtonsoft.Json;


public static class InventoryManager
{
    // reads the json
    public static List<Plant> ReadInventory(string dataset)
    {
        string jsonString = File.ReadAllText(dataset);
        return JsonConvert.DeserializeObject<List<Plant>>(jsonString)!;
    }
    // returns all plants with low inventory using where
    public static List<Plant> DetectLowInventory(List<Plant> inventory)
    {
        List<Plant> returnList = inventory.Where(x => x.Stock < 5).ToList();
        returnList.Sort();
        return returnList;
    }
    // returns all plants of a category
    public static List<Plant> SearchByCategory(List<Plant> inventory, string category) => inventory.Where(x => x.Category == category).ToList();
    // returns all of the plants sold on the last selling date
    public static List<Plant> LastSoldItems(List<Plant> inventory)
    {
        DateOnly newest = inventory.MaxBy(x => x.LastSold)!.LastSold;
        return inventory.Where(x => x.LastSold == newest).ToList();
    }
    // returns a couple of possible plants to remove (DateOnly cutoff was due to time being, you know, moving, which was unaccounted for in the original excercise)
    public static List<Plant> PotentialRemoval(List<Plant> inventory)
    {
        DateOnly cutoff = new DateOnly(day: 21, month: 11, year: 2023).AddMonths(-16);
        return inventory.Where(x => x.LastSold < cutoff && x.Stock >= 10).ToList();
    }
}
