using System.Globalization;
using System.Xml.Linq;

public class Plant : IComparable<Plant>
{
    public string Name { get; set; } 
    public string Category { get; set; } 
    private int _stock; 
    // minimum stock is 0
    public int Stock
    {
        get { return _stock; }
        private set 
        { 
            if(value > 0) { _stock = value; }
            else { _stock = 0; }
        }
    }
    public DateOnly LastSold { get; set; }
    public Plant(string name, string category, int stock, string lastSold)
    {
        Name = name;
        Category = category;
        _stock = stock;
        LastSold = DateOnly.ParseExact(lastSold, "dd-MM-yyyy", CultureInfo.InvariantCulture);
    }
    // sells the amount of this plant
    public int Sell(int amount)
    {
        int amountSold = 0;
        if(amount <= Stock){ amountSold = amount; }
        else if(amount > Stock){ amountSold = Stock; }
        Stock = Stock - amountSold;
        LastSold = DateOnly.FromDateTime(DateTime.Now);
        return amountSold;
    }
    // IComparable for the list of plants
    public int CompareTo(Plant? other)
    {
        return other == null ? 1 : Stock.CompareTo(other.Stock);
    }
}
