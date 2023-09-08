using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static Dictionary<string, int> CountWordFrequency(string input)
    {
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

        // Remove punctuation marks using regular expression
        string cleanedInput = Regex.Replace(input, @"\p{P}", "");

        // Split the cleaned input into words
        string[] words = cleanedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Count the frequency of each word
        foreach (string word in words)
        {
            string lowercaseWord = word.ToLower();
            if (frequencyMap.ContainsKey(lowercaseWord))
            {
                frequencyMap[lowercaseWord]++;
            }
            else
            {
                frequencyMap[lowercaseWord] = 1;
            }
        }

        return frequencyMap;
    }

    static void Main()
    {
        string input = "Hello, hello! How are you today? I hope you are doing well.";

        Dictionary<string, int> wordFrequency = CountWordFrequency(input);

        // Print the word frequency
        foreach (var kvp in wordFrequency)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}