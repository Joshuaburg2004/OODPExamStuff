// uses where contraint, should be done this way
public class Tower<TShape> where TShape : IStackable
{
    public readonly TShape[] Shapes;
    public int Index { get; private set; } = 0;
    public Tower(int size) => Shapes = new TShape[size];
    public Tower(Tower<TShape> tower)
    {
        this.Shapes = tower.Shapes;
        this.Index = tower.Index;
    }

    public void Add(TShape shape)
    {
        try
        {
            Shapes[Index] = shape;
            Index++;
        }
        catch(IndexOutOfRangeException)
        {
            return;
        }
    }
    // overloads + operator
    public static Tower<TShape> operator +(Tower<TShape> tower, TShape shape)
    {
        Tower<TShape> new_tower = new(tower);
        new_tower.Add(shape);
        return new_tower;
    }
}
