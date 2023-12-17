using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models;

public class Book
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    public string Name { get; set; } = null!;

    [Display(Name = "Рік видання")]
    public int Year { get; set; }

    [Display(Name = "Опис")]
    public string? Description { get; set; } = "Немає опису.";

    [Display(Name = "Кількість оцінок")]
    public int TimesRated { get; set; } = 0;

    [Display(Name = "Середня оцінка")]
    public double AverageRating { get; set; } = 0;
}