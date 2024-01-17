public class ParkingLot
{
    // sizes for each position in the lot
    public int[][] NumColsArr { get; }
    // the lot
    public ParkingSpace[][] parkingLot;
    public ParkingLot(int[] numColsArr)
    {
        // loops through numcolsarr, making the lot as it does
        NumColsArr = new int[numColsArr.Length][];
        parkingLot = new ParkingSpace[numColsArr.Length][];
        for(int i = 0; i < numColsArr.Length; i++)
        {
            NumColsArr[i] = new int[numColsArr[i]];
            parkingLot[i] = new ParkingSpace[numColsArr[i]];
            if (numColsArr[i] > 4)
            {
                for (int j = 0; j < numColsArr[i]; j++)
                {
                    NumColsArr[i][j] = 1;
                    parkingLot[i][j] = new ParkingSpace(i, j, 1);
                }
            }
            else
            {
                for (int j = 0; j < numColsArr[i]; j++)
                {
                    NumColsArr[i][j] = 2;
                    parkingLot[i][j] = new ParkingSpace(i, j, 2);
                }
            }
        }
    }
    // tries to park a vehicle
    public bool ParkVehicle(Vehicle vehicle, ParkingSpace parkingSpace)
    {
        bool worked = parkingSpace.ParkVehicle(vehicle);
        if (worked) { parkingLot[parkingSpace.Row][parkingSpace.Col] = parkingSpace; }
        return worked;
    }
    // returns a parking space if one is available, returns null otherwise
    public ParkingSpace? FindAvailableSpace(Vehicle? vehicle)
    {
        foreach (ParkingSpace[] array in parkingLot)
        {
            foreach(ParkingSpace space in array)
            {
                if (vehicle.Size == space.Size && !space.IsOccupied) { return space; }
            }
        }
        return null;
    }
    // returns how many cars are parked already at a given time
    public int NumCarsParked()
    {
        int amount = 0;
        foreach (ParkingSpace[] array in parkingLot)
        {
            foreach (ParkingSpace space in array)
            {
                if(space.vehicle is Car) { amount++; }
            }
        }
        return amount;
    }
    // returns how many trucks are parked already at a given time
    public int NumTrucksParked()
    {
        int amount = 0;
        foreach (ParkingSpace[] array in parkingLot)
        {
            foreach (ParkingSpace space in array)
            {
                if (space.vehicle is Truck) { amount++; }
            }
        }
        return amount;
    }
}
