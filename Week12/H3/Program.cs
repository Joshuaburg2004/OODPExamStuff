// palindrome checker
public class Program
{
    public static void Main(string[] args)
    {
        string[] inputStrArr = args[1..^0];
        //Input strings for first test:
        //"racecar", "hello", "level", "A man, a plan, a canal, Panama!";

        foreach (string str in inputStrArr)
        {
            //Make lowercase and remove non-letters
            string cleanedStr = new string(str.ToLower().Where(c => char.IsLetter(c)).ToArray());
            
            bool isPalindrome = IsPalindrome(cleanedStr);
            Console.WriteLine($"\"{cleanedStr}\" is {(isPalindrome ? "a palindrome" : "not a palindrome")}");
        }
    }

    //Method Palindrome goes here
    public static bool IsPalindrome(string myWord)
    {
        // always return true if it is of length 0 or 1.
        if(myWord.Length == 0 || myWord.Length == 1)
        {
            return true;
        }
        // if the first and last characters match, returns the method
        else if(myWord[0] == myWord[^1])
        {
            string newWord = myWord.Substring(1, myWord.Length - 2);
            return IsPalindrome(newWord);
        }
        // otherwise, returns false
        return false;
    }
}
