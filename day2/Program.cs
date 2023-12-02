using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        var input = File.ReadLines("input.txt");
        var answer1 = SolveTaskPart1(input);
        var answer2 = SolveTaskPart2(input);
        Console.WriteLine($"Answer 1: {answer1}, Answer 2: {answer2}");
    }

    private static object SolveTaskPart2(IEnumerable<string> input)
    {
        return String.Empty;
    }

    private static object SolveTaskPart1(IEnumerable<string> input)
    {
        var playedGames = new List<Game>();

        foreach (var line in input.ToList())
        {
            var currentGame = new Game();
            currentGame.TriesInGame = new List<Reveal>();
            var colonIndex = line.IndexOf(':');
            int gameIndex = line.IndexOf("Game");

            currentGame.ID = line.Substring(gameIndex + 4, colonIndex - gameIndex - 4).Trim();
            var revealedCubes = line.Substring(colonIndex + 1);

            var separateReveals = revealedCubes.Split(';');

            foreach (var reveal in separateReveals)
            {
                List<Tuple<int, string>> throws = new List<Tuple<int, string>>();

                var currentTry = new Reveal();
                currentTry.Reveals = new List<List<Cube>>();
                if (reveal.Contains(','))
                {
                    var list = new List<Cube>();
                    foreach (var currentThrow in reveal.Split(','))
                    {
                        list.Add(SetCubeDetails(currentThrow));
                    }



                    currentTry.Reveals.Add(list);
                }
                else
                {
                    var list = new List<Cube>();
                    list.Add(SetCubeDetails(reveal));
                    currentTry.Reveals.Add(list);
                }

                currentGame.TriesInGame.Add(currentTry);
            }

            playedGames.Add(currentGame);
        }

        var validGames = new List<Game>();

        foreach (var game in playedGames)
        {
            bool valid = true;
            foreach (var tryIngame in game.TriesInGame)
            {
                foreach (var reveal in tryIngame.Reveals)
                {
                    if (reveal.Where(x => x.Color == CubeColor.Red).Sum(x => x.Amount) <= 12 &&
                    reveal.Where(x => x.Color == CubeColor.Green).Sum(x => x.Amount) <= 13 &&
                    reveal.Where(x => x.Color == CubeColor.Blue).Sum(x => x.Amount) <= 14)
                    {
                        continue;
                    }

                    valid = false;
                }

            }
            if (valid)
            {
                validGames.Add(game);
            }


        }

        return validGames.Sum(x => Int32.Parse(x.ID));

    }

    private static Cube SetCubeDetails(string reveal)
    {
        var amountAndColor = reveal.TrimStart().Split(' ');
        var currentThrow = new Tuple<int, string>(Int32.Parse(amountAndColor.First().Trim()), amountAndColor.Last().Trim());

        return new Cube(SetCubeColor(currentThrow.Item2), currentThrow.Item1);
    }

    private static CubeColor SetCubeColor(string color)
    {
        switch (color)
        {
            case "red":
                return CubeColor.Red;
            case "green":
                return CubeColor.Green;
            case "blue":
                return CubeColor.Blue;
        }

        return CubeColor.None;
    }

    public class Game
    {
        public string ID { get; set; }
        public List<Reveal> TriesInGame { get; set; }
    }

    public class Reveal
    {
        public List<List<Cube>> Reveals { get; set; }
    }

    public class Cube
    {
        public CubeColor Color { get; set; }
        public int Amount { get; set; }

        public Cube(CubeColor color, int amount)
        {
            Color = color;
            Amount = amount;
        }
    }

    public enum CubeColor
    {
        Red,
        Green,
        Blue,
        None
    }
}