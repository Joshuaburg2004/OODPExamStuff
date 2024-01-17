public static class DnaStrand
{
    // return complementary strand
    public static string ComplementaryStrand(string strand)
    {
        string new_strand = "";
        foreach (char chr in strand)
        {
            // check if char is a specific thing, then change it for the new strand
            char new_chr;
            if(chr == 'A') { new_chr = 'T'; new_strand += new_chr; }
            if(chr == 'T') { new_chr = 'A'; new_strand += new_chr; }
            if(chr == 'C') { new_chr = 'G'; new_strand += new_chr; }
            if(chr == 'G') { new_chr = 'C'; new_strand += new_chr; }
        }
        // shenanigens to reverse string
        char[] stringArray = new_strand.ToCharArray();
        Array.Reverse(stringArray);
        new_strand = new string(stringArray);
        return new_strand;
    }
    // check if strand is correct
    public static bool IsValidDnaStrand(string DNA)
    {
        if(DNA is null) { return false; }
        foreach(char chr in DNA)
        {
            if(chr != 'A' && chr != 'T' && chr != 'G' && chr != 'C')
            {
                return false;
            }
        }
        return true;
    }
    // should be string? DNA
    public static string? Transcribe(string DNA)
    {
        // change T to U, rest is left alone
        string RNA = "";
        if(DNA is null) { return null; }
        foreach(char chr in DNA)
        {
            if (chr == 'T') { RNA += 'U'; }
            else { RNA += chr; }
        }
        return RNA;
    }
    // return the amount of differences between 1 and 2
    public static int? HammingDistance(string DNA1, string DNA2)
    {
        int returnValue = 0;
        if(DNA1 is null || DNA2 is null) { return null; }
        if(DNA1.Length != DNA2.Length) { return -1; }
        for(int i = 0; i < DNA1.Length; i++)
        {
            if (DNA1[i] != DNA2[i])
                returnValue++;
        }
        return returnValue;
    }
}
