// See https://aka.ms/new-console-template for more information
using AOC;
Console.WriteLine("Rock Paper Scissors!");

string winAction = "win";
string loseAction = "lose";
string drawAction = "draw";

string[] input = await File.ReadAllLinesAsync("./input.txt");
int score = 0;

for (int i = 0; i < input.Length; i++)
{
    int roundScore = 0;
    string[] round = input[i].Split(" ");

    RockPaperScissor enemy = RockPaperOrScissor(round[0]);
    string me = WinLoseOrDraw(round[1]);

    Console.WriteLine($"Enemy plays {enemy}, I play {me}");
    roundScore = CalculateRoundScore(enemy, me);
    Console.WriteLine($"Round score: {roundScore}");

    score += roundScore;
}

string WinLoseOrDraw(string X)
{
    switch (X)
    {
        case "X":
            return loseAction;
        case "Y":
            return drawAction;
        case "Z":
            return winAction;
        default:
            return string.Empty;
    }
}

Console.WriteLine();
Console.WriteLine($"Total score after {input.Length} rounds: {score}");

int CalculateRoundScore(RockPaperScissor enemy, string me)
{
    int win = 6;
    int draw = 3;
    int loss = 0;

    switch (enemy)
    {
        case RockPaperScissor.Rock:
            if (me == winAction)
            {
                return win + (int)RockPaperScissor.Paper;
            }
            else if (me == loseAction)
            {
                return loss + (int)RockPaperScissor.Scissor;
            }
            else
            {
                return draw + (int)RockPaperScissor.Rock;
            }
        case RockPaperScissor.Paper:
            if (me == winAction)
            {
                return win + (int)RockPaperScissor.Scissor;
            }
            else if (me == loseAction)
            {
                return loss + (int)RockPaperScissor.Rock;
            }
            else
            {
                return draw + (int)RockPaperScissor.Paper;
            }
        case RockPaperScissor.Scissor:
            if (me == winAction)
            {
                return win + (int)RockPaperScissor.Rock;
            }
            else if (me == loseAction)
            {
                return loss + (int)RockPaperScissor.Paper;
            }
            else
            {
                return draw + (int)RockPaperScissor.Scissor;
            }
        default:
            return 0;
    }
}

RockPaperScissor RockPaperOrScissor(string action)
{
    switch (action)
    {
        case "A":
        case "X":
            return RockPaperScissor.Rock;
        case "B":
        case "Y":
            return RockPaperScissor.Paper;
        case "C":
        case "Z":
            return RockPaperScissor.Scissor;
        default:
            return RockPaperScissor.Invalid;
    }
}