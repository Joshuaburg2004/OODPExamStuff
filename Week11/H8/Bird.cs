using System.Reflection.Metadata;

public class Bird : Animal
{
    // shows inheritance of a class
    public int FlightDistanceInKM { get; }
    public Bird(string species, int age, int flightDistanceInKM) : base(species, age) { FlightDistanceInKM = flightDistanceInKM; }

}
