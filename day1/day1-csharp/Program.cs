using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = File.ReadLines("input.txt");
        var answer1 = SolveTaskPart1(input);
        var answer2 = SolveTaskPart2(input);
        Console.WriteLine($"Answer 1: {answer1}, Answer 2: {answer2}");
    }

    private static int SolveTaskPart1(IEnumerable<string> input)
    {
        int result = 0;
        foreach (var line in input.ToList())
        {
            List<int> numbersFoundInLine = new List<int>();

            foreach (var character in line)
            {
                if (Int32.TryParse(character.ToString(), out int number))
                    numbersFoundInLine.Add(number);
            }

            if (numbersFoundInLine.Count > 0)
                result = AddFirstAndLastDigitInLine(result, numbersFoundInLine);
        }

        return result;
    }

    private static int AddFirstAndLastDigitInLine(int result, List<int> numbersFoundInLine)
    {
        var constructedNumber = $"{numbersFoundInLine.First()}" + $"{numbersFoundInLine.Last()}";
        result += Int32.Parse(constructedNumber);
        return result;
    }

    private static int SolveTaskPart2(IEnumerable<string> input)
    {
        int result = 0;
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
            { "nine", 9 },
            { "0", 0 },
            { "1", 1 },
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 }
        };


        foreach (var line in input.ToList())
        {
            var numbersFoundInLine = new List<int>();

            var allPossibleSubstrings =
            from i in Enumerable.Range(0, line.Length)
            from j in Enumerable.Range(0, line.Length - i + 1)
            where j >= 1
            select line.Substring(i, j);

            foreach (var substring in allPossibleSubstrings)
            {
                if (stringToNumber.ContainsKey(substring))
                {
                    numbersFoundInLine.Add(stringToNumber[substring]);
                }
            }

            if (numbersFoundInLine.Count > 0)
                result = AddFirstAndLastDigitInLine(result, numbersFoundInLine);
        }

        return result;
    }



}