public class Car : IEquatable<Car>
{
    public readonly string Make;
    public readonly string Model;
    // new Array with Tire objects
    public readonly Tire[] Tires = new Tire[4];
    public Car(string make, string model, string tireBrand)
    {
        Make = make;
        Model = model;
        Tires[0] = new Tire(tireBrand);
        Tires[1] = new Tire(tireBrand);
        Tires[2] = new Tire(tireBrand);
        Tires[3] = new Tire(tireBrand);
    }

    public bool TryDrive()
    {
        bool canDrive = true;
        // Check if all tires are fine
        foreach(Tire tire in Tires)
        {
            if (tire.Durability < 1) { canDrive = false; }
        }
        if (canDrive)
        {
            // Could be the same for(Tire tire in tires) loop as before, just replace the content with tire.Durability -= 1;
            Tires[0].Durability -= 1;
            Tires[1].Durability -= 1;
            Tires[2].Durability -= 1;
            Tires[3].Durability -= 1;
            return true;
        }
        return false;
    }
    
    public void ReplaceTire(Tire tire, int i)
    {
        // if i is in the array, change that tire
        if(i < Tires.Length && i >= 0)
        {
            Tires[i] = tire;
        }
    }

    public void ReplaceTire(string tireBrand, int i)
    {
        // see above replaceTire, just with making a new Tire object in the method
        Tire tire = new Tire(tireBrand);
        if (i < Tires.Length && i >= 0)
        {
            Tires[i] = tire;
        }
    }

    public string GetTireInfo()
    {
        // Could be :
        // string info = "";
        // for(int i = 0; i < tires.Length; i++){info += $"Tire {i + 1}: Brand: {Tires[i].Brand}, Durability: {Tires[i].Durability}\n";
        string info1 = $"Tire 1: Brand: {Tires[0].Brand}, Durability: {Tires[0].Durability}\n";
        string info2 = $"Tire 2: Brand: {Tires[1].Brand}, Durability: {Tires[1].Durability}\n";
        string info3 = $"Tire 3: Brand: {Tires[2].Brand}, Durability: {Tires[2].Durability}\n";
        string info4 = $"Tire 4: Brand: {Tires[3].Brand}, Durability: {Tires[3].Durability}\n";
        string info = info1 + info2 + info3 + info4;
        return info;
    }
    // usual IEquatable<Car> stuff
    public bool Equals(Car? car)
    {
        if(car is not null)
        {
            if (car.Make == Make && car.Model == Model) { return true; }
        }
        return false;
    }

    public static bool operator ==(Car? car1, Car? car2)
    {
        if(car1 is null && car2 is null) { return true; }
        if((car1 is null && car2 is not null) || (car1 is not null && car2 is null)) { return false; }
        if(car1 is not null && car2 is not null) { return car1.Equals(car2); }
        return false;
    }

    public static bool operator !=(Car? car1, Car? car2)
    {
        if (car1 is null && car2 is null) { return false; }
        if ((car1 is null && car2 is not null) || (car1 is not null && car2 is null)) { return true; }
        if (car1 is not null && car2 is not null) { return !car1.Equals(car2); }
        return true;
    }
}
