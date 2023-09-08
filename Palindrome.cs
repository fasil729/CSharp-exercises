using System;

class Program
{
    static bool IsPalindrome(string input)
    {
        // Remove spaces, punctuation, and convert to lowercase
        string cleanedInput = RemoveSpacesAndPunctuation(input).ToLower();

        // Check if the cleaned string is a palindrome
        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    static string RemoveSpacesAndPunctuation(string input)
    {
        string cleanedInput = "";
        foreach (char c in input)
        {
            if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c))
            {
                cleanedInput += c;
            }
        }
        return cleanedInput;
    }

    static void Main()
    {
        string input = "A man, a plan, a canal, Panama";

        bool isPalindrome = IsPalindrome(input);

        Console.WriteLine($"Is Palindrome? {isPalindrome}");
    }
}