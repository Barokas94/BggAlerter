namespace BggAlerter
{
    public class Game
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }

        public Game()
        {
        }

        public Game(int position, string name, int year, double rating)
        {
            Position = position;
            Name = name;
            Year = year;
            Rating = rating;
        }
    }
}
