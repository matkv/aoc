using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, int> stringToNumber = new Dictionary<string, int>
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        var lines = File.ReadLines("exampleinput.txt");
        int totalSum = 0;

        foreach (var line in lines)
        {
            List<int> foundNumbers = new List<int>();

            var charactersInLine = line.ToCharArray();

            var wordToTry = String.Empty;
            foreach (var character in charactersInLine.ToList())
            {
                if (Int32.TryParse(character.ToString(), out int digit))
                    continue;


                wordToTry += character;

                if (stringToNumber.TryGetValue(wordToTry.ToLower(), out int number))
                {
                    foundNumbers.Add(number);
                    wordToTry = String.Empty;
                }
            }

            if (foundNumbers.Count > 0)
            {
                var numberAsString = foundNumbers.First().ToString() + foundNumbers.Last().ToString();

                if (Int32.TryParse(numberAsString, out int parsedNumber))
                    totalSum += parsedNumber;
            }
        }

        var result = totalSum;
    }
}