// See https://aka.ms/new-console-template for more information


using System.Linq;

Console.WriteLine("Hello, World!");

Dictionary<char, int> _lowercasePrio = new Dictionary<char, int>();
for (char c = 'a'; c <= 'z'; c++)
{
    int key = c - 'a' + 1;
    _lowercasePrio.Add(c, key);
}

Dictionary<char, int> _uppercasePrio = new Dictionary<char, int>();

for (char c = 'A'; c <= 'Z'; c++)
{
    int key = c - 39 + 1;
    _uppercasePrio.Add(c, key);
}

var input = File.ReadAllLines("./input.txt").Chunk(3);
int totalScore = 0;

IEnumerable<char> chars;

int charOccurence = 0;

foreach (var item in input)
{
    IEnumerable<char> result = item[0].Intersect(item[1]).Intersect(item[2]);
    totalScore+= _lowercasePrio.GetValueOrDefault(result.First(),0);
    totalScore+= _uppercasePrio.GetValueOrDefault(result.First(),0);
}

System.Console.WriteLine(totalScore);

