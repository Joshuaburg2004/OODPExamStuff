// container class
public class Container
{
    public string Code { get; }
    public string Manifest { get; }
    public string[] Categories { get; }
    public string Origin { get; }
    public double Weight { get; }
    public ContainerStatus Status { get; set; }
    public double ActualWeight { get; }
    public Container(string code, string manifest, string[] categories, string origin, string weight, string actual_weight)
    {
        Code = code;
        Manifest = manifest;
        Categories = categories;
        Origin = origin;
        weight = weight.Replace(",", "");
        // replaces lbs to nothing so it can be a double
        weight = weight.Replace("lbs", "");
        // converts to kilo's
        Weight = Math.Round(Convert.ToDouble(weight) * 0.45359237, 2);
        Status = ContainerStatus.Processing;
        actual_weight = actual_weight.Replace(",", "");
        actual_weight = actual_weight.Replace("lbs", "");
        ActualWeight = Math.Round(Convert.ToDouble(actual_weight) * 0.45359237, 2);
    }

    public override string ToString()
    {
        // shenanigens for the proper output
        string output = $"Container(Code:'{Code}', Manifest:'{Manifest}', Categories:'";
        string add = string.Join(',', Categories);
        output += add;
        output += $"', Origin:'{Origin}', Status:'{Status}', Weight:'{Weight}', ActualWeight:'{ActualWeight}')";
        return output;
    }
}
