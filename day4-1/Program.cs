// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static int CalculateNumbersInList(List<int> totalRange1, List<int> totalRange2)
{
    int listCount = 0;
    for (int k = 0; k < totalRange1.Count; k++)
    {
        if (totalRange2.Contains(totalRange1[k]))
        {
            listCount++;
        }
    }

    return listCount;
}

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

    if(totalRange1.Count == CalculateNumbersInList(totalRange1, totalRange2) || totalRange2.Count == CalculateNumbersInList(totalRange2, totalRange1))
    {
        totalScore++;
    }
}

System.Console.WriteLine(totalScore);