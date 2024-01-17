public class ParkingSpace
{
    public int Row { get; }
    public int Col { get; }
    public int Size { get; }
    public bool IsOccupied { get { return vehicle is not null; } }
    public Vehicle? vehicle = null;
    // purely for parkingLot, could've been incorporated there
    public ParkingSpace(int row, int col, int size) { Row = row; Col = col; Size = size; }
    public bool ParkVehicle(Vehicle? vehicle)
    {
        if (IsOccupied) { return false; }
        this.vehicle = vehicle;
        return true;
    }
    public Vehicle? GetVehicle() => vehicle;
}
