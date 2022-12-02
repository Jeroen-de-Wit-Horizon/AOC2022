namespace AOC
{
    public record Elf
    {
        public List<Food> Foods { get => _foods; set => _foods = value; }
        public int TotalNumberOfCalories = 0;
        private List<Food> _foods = new List<Food>();

        public async Task<int> CalculateTotalCalories()
        {
            return _foods.Sum(t=> t.Calories);
        }
    }
}