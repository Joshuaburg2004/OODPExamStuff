// exception if out of range
public class MyIndexOutOfRangeException : Exception
{
    public MyIndexOutOfRangeException() { }
    public MyIndexOutOfRangeException(string message)
        : base(message) { }
    public MyIndexOutOfRangeException(string message, Exception innerException)
        : base(message, innerException) { }
}
