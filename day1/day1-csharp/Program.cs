using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

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

            var constructedNumber = $"{numbersFoundInLine.First()}" + $"{numbersFoundInLine.Last()}";
            result += Int32.Parse(constructedNumber);
        }

        return result;
    }

    private static int SolveTaskPart2(IEnumerable<string> input)
    {
        return 0;
    }



}