namespace LibraryAPI.Models;

public class Article
{
    public int Id { get; }

    public string Title { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string? Text { get; set; } = "Немає опису.";
}