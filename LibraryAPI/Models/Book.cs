using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models;

[PrimaryKey("Id")]
public class Book : IUpdatable<Book>
{
    [Column("book_id"), Key]
    public int Id { get; }

    [Column("book_name")]
    public string Name { get; set; } = null!;

    [Column("book_year")]
    public int Year { get; set; }

    [Column("book_description")]
    public string? Description { get; set; } = "Немає опису";

    [Column("book_timesrated")]
    public int TimesRated { get; set; } = 0;

    [Column("book_averagerating")]
    public double AverageRating { get; set; } = 0;

    public void UpdateInstance(Book input) {
        Name = input.Name;
        Year = input.Year;
        Description = input.Description;
        TimesRated = input.TimesRated;
        AverageRating = input.AverageRating;
    }
}

public interface IUpdatable<T>
{
    public void UpdateInstance (T input);
}