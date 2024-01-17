// operator overloading for + and *
public class Robot
{
    private int _power;
    public int Power
    {
        get => _power;
        private set
        {
            if (value <= 0)
                value = 0;
            _power = value;
        }
    }

    public bool IsFused { get; private set; }
    public Robot(int power) { Power = power; }
    private Robot(int power, bool isFused) { Power = power; IsFused = isFused; }
    public int Attack()
    {
        int power = Power;
        if (IsFused)
        {
            Power /= 2;        
        }
        return power;
    }

    public static Robot? operator +(Robot? r1, Robot? r2)
    {
        if(r1 is null && r2 is null)
        {
            return new Robot(0, false);
        }
        if(r1 is null && r2 is not null)
        {
            return r2;
        }
        if(r2 is null && r1 is not null)
        {
            return r1;
        }
        if (r1 is not null && r2 is not null)
            return new Robot(r1.Power + r2.Power, false);
        return null;
    }

    public static Robot? operator *(Robot? r1, Robot? r2)
    {
        if (r1 is null && r2 is null)
        {
            return new Robot(0, false);
        }
        if (r1 is null && r2 is not null)
        {
            return r2;
        }
        if (r2 is null && r1 is not null)
        {
            return r1;
        }
        if (r1 is not null && r2 is not null)
            return new Robot(r1.Power * r2.Power, true);
        return null;
    }
}
