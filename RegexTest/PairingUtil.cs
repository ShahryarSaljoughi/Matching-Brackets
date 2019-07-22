using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class PairingUtil
{
    public static Dictionary<char, char> ClosingPairs = new Dictionary<char, char>() {
        {'(', ')'},
        {'{', '}'},
        {'[', ']'}
    };

    public static bool IsPaired(string input)
    {
        input = Regex.Replace(input, @"\s", "");
        if(input.Length < 3)
            return new List<string>(){"()", "{}", "[]", ""}.Any(t => t == input);
        var divideSuccessfull = Divide(input, out var substrings);
        return divideSuccessfull ? 
            substrings.All(s => IsPaired(s.Substring(1, s.Length-2))): false;
    }

    private static bool Divide(string input, out List<string> result)
    {
        result = new List<string>();
        int pairOpeningIndex=0;
        char pairOpeningChar;
        int i = 1;  // whenever i becomes zero, means either we ha walked through an entire pair, or no pair is found!
        for(var j = 1; j < input.Length; j++ )
        {
            pairOpeningChar = input[pairOpeningIndex];
            try
            {
                if( input[j] == pairOpeningChar)
                    i++;
                else if ( input[j] == ClosingPairs[pairOpeningChar])
                    i--;    
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            if ( i==0)
            {
                result.Add(input.Substring(pairOpeningIndex, j - pairOpeningIndex + 1));
                pairOpeningIndex = j + 1;
            }            
        }
        return result.Aggregate((s1, s2) => s1 + s2) == input;
    }
}