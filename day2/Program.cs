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

        var cubesForPossibleGames = new List<Cube>() {
            new Cube(CubeColor.Red, 12),
            new Cube(CubeColor.Green, 13),
            new Cube(CubeColor.Blue, 14)

        };

        var totalRedCubes = new List<Cube>();
        var totalGreenCubes = new List<Cube>();
        var totalBlueCubes = new List<Cube>();


        foreach (var line in input.ToList())
        {
            var currentGame = new Game();
            currentGame.foundCubes = new List<Cube>();
            var colonIndex = line.IndexOf(':');
            int gameIndex = line.IndexOf("Game");


            currentGame.ID = line.Substring(gameIndex + 4, colonIndex - gameIndex - 4).Trim();
            var revealedCubes = line.Substring(colonIndex + 1);

            var separateReveals = revealedCubes.Split(';');

            foreach (var reveal in separateReveals)
            {
                var cubeInfo = reveal.Trim().Replace(",", "").Split(' ');

                var currentThrow = new Cube();
                currentThrow.Amount = Int32.Parse(cubeInfo.First().Trim());

                var color = cubeInfo.Last().Trim();
                switch (color)
                {
                    case "red":
                        currentThrow.Color = CubeColor.Red;
                        break;
                    case "green":
                        currentThrow.Color = CubeColor.Green;
                        break;
                    case "blue":
                        currentThrow.Color = CubeColor.Blue;
                        break;
                }

                currentGame.foundCubes.Add(currentThrow);
            }

            if (currentGame.foundCubes.Count > 0)
            {
                foreach (var cube in currentGame.foundCubes)
                {

                    switch (cube.Color)
                    {
                        case CubeColor.Red:
                            totalRedCubes.Add(cube);
                            break;
                        case CubeColor.Green:
                            totalGreenCubes.Add(cube);
                            break;
                        case CubeColor.Blue:
                            totalBlueCubes.Add(cube);
                            break;
                    }
                }

            }

            playedGames.Add(currentGame);
        }

        var validGames = new List<Game>();

        foreach (var game in playedGames)
        {
            //TODO need to sum the amounts here per color

            if (game.foundCubes.Where(x => x.Color == CubeColor.Red && x.Amount <= 12).FirstOrDefault() != null &&
               game.foundCubes.Where(x => x.Color == CubeColor.Green && x.Amount <= 13).FirstOrDefault() != null &&
                game.foundCubes.Where(x => x.Color == CubeColor.Blue && x.Amount <= 14).FirstOrDefault() != null)
            {
                validGames.Add(game);
            }
        }

        return validGames.Sum(x => Int32.Parse(x.ID));

    }

    public class Game
    {
        public string ID { get; set; }
        public List<Cube> foundCubes { get; set; }
    }

    public class Cube
    {
        public CubeColor Color { get; set; }
        public int Amount { get; set; }

        public Cube()
        {

        }

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
        Blue
    }
}