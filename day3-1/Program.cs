// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Dictionary<string, int> _lowercasePrio = new Dictionary<string, int>();
for(char c = 'a'; c <= 'z'; c++) {
    int key = c - 'a' + 1;
    _lowercasePrio.Add(c.ToString(),key );
}

Dictionary<string, int> _uppercasePrio = new Dictionary<string, int>();

for(char c = 'A'; c <= 'Z'; c++) {
    int key = c - 39 + 1;
    _uppercasePrio.Add(c.ToString(), key);
}

var input = await File.ReadAllLinesAsync("./input.txt");
int totalScore = 0;
for (int i = 0; i < input.Length; i++)
{
    var containers = input[i].Chunk(input[i].Length / 2);
    var containerLeftDistinct = containers.First().Distinct().ToArray();
    var containerRightDistinct = containers.Last().Distinct().ToArray();

    for (int j = 0; j < containerLeftDistinct.Length; j++)
    {
        if (containerRightDistinct.Contains(containerLeftDistinct[j]))
        {
            totalScore += _lowercasePrio.GetValueOrDefault(containerLeftDistinct[j].ToString(), 0);
            totalScore += _uppercasePrio.GetValueOrDefault(containerLeftDistinct[j].ToString(), 0);
        }
    }
}

System.Console.WriteLine(totalScore);

