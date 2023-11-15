using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a piece of text:");
        string inputText = Console.ReadLine();

        int wordCount = CountWords(inputText);
        Console.WriteLine($"Word Count: {wordCount}");

        string[] emailAddresses = GetEmailAddresses(inputText);
        Console.WriteLine("Email Addresses:");
        foreach (var email in emailAddresses)
        {
            Console.WriteLine(email);
        }

        string[] mobileNumbers = ExtractMobileNumbers(inputText);
        Console.WriteLine("Mobile Numbers:");
        foreach (var number in mobileNumbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("Enter a custom regex pattern:");
        string customRegexPattern = Console.ReadLine();
        string[] customRegexMatches = PerformCustomRegexSearch(inputText, customRegexPattern);
        Console.WriteLine("Custom Regex Matches:");
        foreach (var match in customRegexMatches)
        {
            Console.WriteLine(match);
        }
    }

    static int CountWords(string text)
    {
        string[] words = text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static string[] GetEmailAddresses(string text)
    {
        var emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");
        var matches = emailRegex.Matches(text);

        string[] emailAddresses = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            emailAddresses[i] = matches[i].Value;
        }

        return emailAddresses;
    }

    static string[] ExtractMobileNumbers(string text)
    {
        var mobileNumberRegex = new Regex(@"\b\d{10}\b");
        var matches = mobileNumberRegex.Matches(text);

        string[] mobileNumbers = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            mobileNumbers[i] = matches[i].Value;
        }

        return mobileNumbers;
    }

    static string[] PerformCustomRegexSearch(string text, string pattern)
    {
        var customRegex = new Regex(pattern);
        var matches = customRegex.Matches(text);

        string[] customRegexMatches = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            customRegexMatches[i] = matches[i].Value;
        }

        return customRegexMatches;
    }
}
