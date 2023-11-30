namespace Lab6RestAPI.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public uint RentalDailyRate { get; set; }

        public uint NumberInStock { get; set; }

    }
}
