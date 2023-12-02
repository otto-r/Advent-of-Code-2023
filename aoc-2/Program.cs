
Console.WriteLine("         øttø");
var COLORS = Enum.GetNames(typeof(ValidationEnum));

string balls = Input.Balls;
string[] games = balls.Split("\n");
var validBallNumbers = new Dictionary<string, int>
{
    { "red", 12 },
    { "green", 13 },
    { "blue", 14 }
};

List<int> sumOfProducts = [];
foreach (var game in games)
{
    // Game
    Console.WriteLine(game);
    string[] subStrings = game.Split([':', ';']);
    var gameNumber = subStrings[0];
    _ = int.TryParse(gameNumber.Replace("Game", "").Trim(), out int gameId);
    var gameOutcome = subStrings.Skip(1).ToArray();
    var minRedBalls = int.MinValue;
    var minGreenBalls = int.MinValue;
    var minBlueBalls = int.MinValue;
    foreach (string draw in gameOutcome)
    {
        // One draw
        var ballsInDraw = draw.Split(',');
        foreach (var oneColorBalls in ballsInDraw)
        {
            // One color drawn
            var extractedColor = COLORS.First(oneColorBalls.Contains);
            _ = int.TryParse(oneColorBalls.Replace(extractedColor, ""), out int numberOfColoredBall);
            validBallNumbers.TryGetValue(extractedColor, out int validNumberOfBalls);

            switch (extractedColor)
            {
                case "red":
                    minRedBalls = numberOfColoredBall > minRedBalls ? numberOfColoredBall : minRedBalls;
                    break;
                case "green":
                    minGreenBalls = numberOfColoredBall > minGreenBalls ? numberOfColoredBall : minGreenBalls;
                    break;
                case "blue":
                    minBlueBalls = numberOfColoredBall > minBlueBalls ? numberOfColoredBall : minBlueBalls;
                    break;
            }
        }
    }
    sumOfProducts.Add(minRedBalls * minGreenBalls * minBlueBalls);
}

Console.WriteLine($"Sum of products: {sumOfProducts.Sum()}");


enum ValidationEnum : int
{
    red = 12,
    green = 13,
    blue = 14,
};