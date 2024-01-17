public class Account : IEquatable<Object>, IComparable<Object>
{
    public int AccountNumber;
    public string AccountHolderName;
    public double Balance;
    // doesn't require IEquatable<Object>, IEquatable<Type> requires something like:
    // public bool Equals(Type? type){if(type.thing == this.thing){return true;}}
    public override bool Equals(Object? obj)
    {
        if (obj is null) { return false; }
        if (obj is not Account) { return false; }
        if (((Account)obj).AccountNumber == AccountNumber && ((Account)obj).AccountHolderName == AccountHolderName && ((Account)obj).Balance == Balance) { return true; }
        return false;
    }
    // operator overload for == which is better than the recent =='s you've written
    public static bool operator ==(Account? a1, Account? a2)
    {
        if (a1 is not null)
            return a1.Equals(a2);
        else if (a2 is not null)
            return a2.Equals(a1);
        return true;
    }
    // operator overload for != which is better than the recent =='s you've written
    public static bool operator !=(Account? a1, Account? a2)
    {
        if (a1 is not null)
            return !a1.Equals(a2);
        else if (a2 is not null)
            return !a2.Equals(a1);
        return false;
    }
    // general with object, do check if(obj as (type you're working with) is null){return 1;}
    public int CompareTo(Object? obj)
    {
        Account a = (Account)obj!;
        return this.AccountNumber.CompareTo(a.AccountNumber);
    }
}
