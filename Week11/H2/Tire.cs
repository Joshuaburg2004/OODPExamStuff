public class Tire
{
    public string Brand { get; }
    // pre-sets Durability to 5.
    public int Durability { get; set; } = 5;
    public Tire(string brand) => Brand = brand;
}
