namespace LibraryAPI.Models;

public class Book
{
    public int Id { get; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public string? Description { get; set; } = "Немає опису.";

    public int TimesRated { get; set; } = 0;
    public double AverageRating { get; set; } = 0;
}