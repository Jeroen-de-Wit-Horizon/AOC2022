namespace AOC
{
    public class Food
    {
        private int _calories;

        public Food(int calories)
        {
            _calories = calories;
        }

        public int Calories { get => _calories; set => _calories = value; }
    }
}