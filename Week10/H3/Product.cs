public class Product: IEquatable<Product>, IComparable<Product>
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public Product(string name, int price, int quantity)
    {
        Name = name; Price = price; Quantity = quantity;
    }
    // from IEquatable<Product> - use for general type except Object
    public bool Equals(Product? obj)
    {
        // can also be if(obj is null), as otherwise it is usually product, still a nice way though
        if(obj is not Product) { return false; }
        if(((Product)obj).Name == Name) { return true; }
        return false;
    }
    // generic == overload - necessary usually with IEquatable
    public static bool operator ==(Product? p1, Product p2)
    {
        if (p1 is null && p2 is null) { return true; }
        if (p1 is not null && p2 is null) { return false; }
        if (p2 is not null && p1 is null) { return false; }
        if (p1 is not null && p2 is not null)
        {
            if (p1.Name == p2.Name) { return true; }
        }
        return false;
    }
    // generic != overload - necessary usually with IEquatable
    public static bool operator !=(Product? p1, Product p2)
    {
        if (p1 is null && p2 is null) { return !true; }
        if (p1 is not null && p2 is null) { return !false; }
        if (p2 is not null && p1 is null) { return !false; }
        if (p1 is not null && p2 is not null)
        {
            if (p1.Name == p2.Name) { return !true; }
        }
        return !false;
    }
    // check if other is null, if so return 1
    public int CompareTo(Product? other)
    {
        Product p = (Product)other!;
        int priceCompare = Price.CompareTo(p.Price);
        if (priceCompare > 0 || priceCompare < 0) { return priceCompare; }
        else { return Name.CompareTo(p.Name); }
    }

    public override string ToString()
    {
        return $"{Name} ({Price} x {Quantity})";
    }
}
