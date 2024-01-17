public static class EmailParser
{
    // returns a ValueTuple
    public static (string? recipient, string? domain, string? topLevelDomain) ParseEmail(string email)
    {
        // check if email contains an @
        if (email.Contains('@'))
        {
            // splits string in two
            string[] emailArray1 = email.Split("@");
            try
            {
                // trim removes spaces and other unecessary stuff from the string
                string recipient = emailArray1[0].Trim();
                // should check if emailArray[1] contains a dot using same method as before
                string domain = emailArray1[1].Trim();
                string topLevelDomain = domain.Split('.')[1].Trim();
                return (recipient, domain, topLevelDomain);
            }
            catch(IndexOutOfRangeException)
            {
                return (null, null, null);
            }
        }
        return (null, null, null);
    }
}
