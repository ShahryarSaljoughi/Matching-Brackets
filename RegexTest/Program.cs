using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "([]){}[]";
            var pattern = @"(\G\(.*\)|\{.*\}|\[.*\])*";
            var r = new Regex(pattern);
            var matches = r.Matches(input);
            foreach(Match match in matches)
            {
                Console.WriteLine("at: " + match.Index + " found: " + match.Value);
            }
        }
    }
}
