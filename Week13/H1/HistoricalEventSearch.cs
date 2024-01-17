using Newtonsoft.Json;

public static class HistoricalEventSearch
{
    // reads out json
    public static List<HistoricalEvent> ReadEvents(string dataset)
    {
        StreamReader reader = new StreamReader(dataset);
        string jsonString = reader.ReadToEnd();
        reader.Close();
        return JsonConvert.DeserializeObject<List<HistoricalEvent>>(jsonString)!;
    }
    // using where, returns wherever the description contains the exact searchterm
    public static List<HistoricalEvent> SearchInDescription(List<HistoricalEvent> list, string search) => list.Where(x => x.Description.Contains(search)).ToList();
    // using where, returns any events between 2 years
    public static List<HistoricalEvent> SearchBetweenYears(List<HistoricalEvent> list, int fromYear, int toYear) => list.Where(x => x.Year >= fromYear && x.Year <= toYear).ToList();
    // using Average, checks what the average year for each event is. (this is always one to large, thus the -1)
    public static int AverageEventYear(List<HistoricalEvent> list) => Convert.ToInt32(list.AsEnumerable().Average(x => x.Year)) - 1;
}
