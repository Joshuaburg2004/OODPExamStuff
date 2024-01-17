// generic T
public class MyData<T>
{
    private T[] _data;
    public MyData(T[] array) => _data = array;

    // Overload the [] indexer here => returns the appropriate part of the _data array
    public T this[int i]
    {
        get 
        { 
            try 
            { 
                return _data[i]; 
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index {i} is out of range.");
                return default;
            }
        }
        set 
        { 
            try 
            { 
                _data[i] = value; 
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index {i} is out of range.");
            }
        }
    }
}
