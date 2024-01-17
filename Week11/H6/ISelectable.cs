// custom interface, adds 2 methods + a property
public interface ISelectable
{
    public bool IsSelected { get; }
    public void Select();
    public void Deselect();
}
