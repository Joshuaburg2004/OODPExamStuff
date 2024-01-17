// custom interface usages, all of the above
public class Square : Shape, ISelectable, IStackable
{
    public bool IsSelected { get; set; } = false;
    public double Size { get; }
    public Square(double size)
    {
        if (size <= 0)
            size = 0;
        Size = size;
    }

    public void Select()
    {
        IsSelected = true;
    }

    public void Deselect()
    {
        IsSelected = false;
    }
}
