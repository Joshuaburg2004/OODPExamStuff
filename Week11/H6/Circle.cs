// working with custom interfaces
public class Circle : Shape, ISelectable
{
    public bool IsSelected { get; set; } = false;
    public double Radius { get; }
    public Circle(double radius)
    {
        if(radius <= 0)
            radius = 0;
        Radius = radius;
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
