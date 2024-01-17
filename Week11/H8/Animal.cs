public class Animal : IEquatable<Animal>
{
    public string Species { get; set; }
    public int Age { get; set; }
    public Animal(string species, int age)
    {
        Species = species;
        Age = age;
    }
    // IEquatable<Animal> Equals
    public bool Equals(Animal? a1)
    {
        if(a1 is null) { return false; }
        if(a1.Species == Species) { return true; }
        return false;
    }
    // Object class Equals Override
    public override bool Equals(object? a1)
    {
        if (a1 is Animal)
        {
            if ((a1 as Animal)!.Species == Species) { return true; }
        }
        return false;
    }
    // both == and != are from IEquatable<animal>
    public static bool operator ==(Animal? a1, Animal? a2)
    {
        if (a1 is null && a2 is null) { return true; }
        if((a1 is null && a2 is not null) || (a1 is not null && a2 is null)){ return false; }
        else
        {
            if (a1.Equals(a2)) { return true; }
        }
        return false;
    }
    public static bool operator !=(Animal? a1, Animal? a2)
    {
        if (a1 is null && a2 is null) { return false; }
        if ((a1 is null && a2 is not null) || (a1 is not null && a2 is null)){ return true; }
        else
        {
            if (a1.Equals(a2)) { return false; }
        }
        return true;
    }
}
