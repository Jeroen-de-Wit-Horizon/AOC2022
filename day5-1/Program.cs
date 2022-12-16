// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

string[] input = await File.ReadAllLinesAsync("input.txt");

string[] moveOrders = input.Where(s=> s.StartsWith("move")).ToArray();
string[] stacks = input.Take(9).ToArray();
Array.Reverse(stacks);

Dictionary<int,Stack<string>> stringStacks = new Dictionary<int, Stack<string>>();

for (int i = 1; i <= 9; i++)
{
    Stack<string> stringStack = new Stack<string>();
    stringStacks.Add(i,stringStack);
}

ParseStringArrayToStacks(stacks, stringStacks);

PushCratesAround(moveOrders, stringStacks);

PrintOutcome(stringStacks);

Console.ReadLine();

static void ParseStringArrayToStacks(string[] stacks, Dictionary<int, Stack<string>> stringStacks)
{
    foreach (string s in stacks)
    {
        if (s.Contains('1'))
            continue;
        for (int j = 0; j < s.Count(); j++)
        {
            string character = s[j].ToString();
            if (!string.IsNullOrWhiteSpace(character) && character != "[" && character != "]")
            {
                int stackForChar = int.Parse(stacks[0][j].ToString());
                Stack<string>? tempStack = stringStacks.GetValueOrDefault(stackForChar);

                if (tempStack != null)
                    tempStack.Push(character);
            }
        }        
    }
}

static void PushCratesAround(string[] moveOrders, Dictionary<int, Stack<string>> stringStacks)
{
    foreach (string s in moveOrders)
    {
        string[] numbers = Regex.Split(s, @"\D+");
        int numberToBeMoved = int.Parse(numbers[1]);
        int fromStackNumber = int.Parse(numbers[2]);
        int toStackNumber = int.Parse(numbers[3]);

        for (int i = 0; i < numberToBeMoved; i++)
        {
            Stack<string>? fromStack = stringStacks.GetValueOrDefault(fromStackNumber);
            Stack<string>? toStack = stringStacks.GetValueOrDefault(toStackNumber);

            if (fromStack != null && toStack != null)
            {
                string toBeMoved = fromStack.Pop();
                toStack.Push(toBeMoved);
            }
        }
    }
}

static void PrintOutcome(Dictionary<int, Stack<string>> stringStacks)
{
    foreach (Stack<string> stackies in stringStacks.Values)
    {
        System.Console.Write(stackies.Peek());
    }
}