// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[] input = File.ReadAllLines("input.txt");
List<int> numbers1 = new List<int>();
List<int> numbers2 = new List<int>();

int totalScore = 0;

for (int i = 0; i < input.Length; i++)
{
    string[] ranges = input[i].Split(",");
    
    int startRange1 = int.Parse(ranges[0].Split("-").First());
    int endRange1 = int.Parse(ranges[0].Split("-").Last());

    int startRange2 = int.Parse(ranges[1].Split("-").First());
    int endRange2 = int.Parse(ranges[1].Split("-").Last());

    int diffRange1 = endRange1 - startRange1;
    int diffRange2 = endRange2 - startRange2;

    List<int> totalRange1 = new List<int>();

    for (int j = 0; j <= diffRange1; j++)
    {
        totalRange1.Add(startRange1 + j);
    }

    List<int> totalRange2 = new List<int>();

    for (int j = 0; j <= diffRange2; j++)
    {
        totalRange2.Add(startRange2 + j);
    }

    if(totalRange1.Intersect(totalRange2).Any() || totalRange2.Intersect(totalRange1).Any())
    {
        totalScore++;
    }
}
System.Console.WriteLine(totalScore);