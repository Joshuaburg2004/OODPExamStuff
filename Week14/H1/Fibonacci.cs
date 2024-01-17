public static class Fibonacci
{
    // long to prevent a too big number
    public static Dictionary<long, long> Numbers = new();
    public static long Calculate(long n)
    {
        // if n is in the keys, return that value
        if (Numbers.Keys.Contains(n)) { return Numbers[n]; }
        else
        {
            if (!(Numbers.Keys.Contains(n - 1) && Numbers.Keys.Contains(n - 2)))
            {
                if (n > 1)
                {
                    // returns the calculation of the previous 2 numbers into the dict
                    Numbers.Add(n, Calculate(n - 1) + Calculate(n - 2));
                }
                // returns standard values
                else if (n == 1) { Numbers[1] = 1; }
                else if (n == 0) { Numbers[0] = 0; }
                return Numbers[n];
            }
            // only needs to check 1 of the 2 numbers for both this and the next else if
            else if (!Numbers.Keys.Contains(n - 1) && Numbers.Keys.Contains(n - 2))
            {
                if (n > 1)
                {
                    Numbers.Add(n, Calculate(n - 1) + Numbers[n - 2]);
                }
                return Numbers[n];
            }
            else if (Numbers.Keys.Contains(n - 1) && !Numbers.Keys.Contains(n - 2))
            {
                if (n > 1)
                {
                    Numbers.Add(n, Numbers[n - 1] + Calculate(n - 2));
                }
                return Numbers[n];
            }
            // otherwise, returns the 2 numbers added together
            else if (Numbers.Keys.Contains(n - 1) && Numbers.Keys.Contains(n - 2))
            {
                if (n > 1)
                {
                    Numbers.Add(n, Numbers[n - 1] + Numbers[n - 2]);
                }
                return Numbers[n];
            }
            return n;
        }
    }
}
