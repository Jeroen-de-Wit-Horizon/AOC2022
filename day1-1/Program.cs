// See https://aka.ms/new-console-template for more information
using AOC;

string input = await File.ReadAllTextAsync("./input.txt");
string[] foods = input.Split("\r\n");
Elf e = new Elf();

List<Elf> elfs = await CalculateCaloriesPerElf(foods);

Console.WriteLine(elfs.Max(e => e.TotalNumberOfCalories));

Console.WriteLine(elfs.OrderByDescending(e=> e.TotalNumberOfCalories).Take(3).Sum(e=> e.TotalNumberOfCalories));

async Task<List<Elf>> CalculateCaloriesPerElf(string[] foods)
{
    List<Elf> _elfs = new List<Elf>();
    
    for (int j = 0; j < foods.Length; j++)
    {
        int tempCalorie = 0;
        int.TryParse(foods[j], out tempCalorie);

        if (tempCalorie != 0)
        {
            e.Foods.Add(new Food(tempCalorie));
        }        
        else
        {
            e.TotalNumberOfCalories = await e.CalculateTotalCalories();
            _elfs.Add(e);
            e = new Elf();
            continue;
        }
    }    

    return _elfs;
}


