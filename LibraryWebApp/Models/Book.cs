using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models;

public class Book
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [StringLength(30, ErrorMessage = "Назва не має бути довшою за 30 символів.")]
    public string Name { get; set; } = null!;

    [Display(Name = "Рік видання")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Поле має містити тільки цифри.")]
    public int Year { get; set; }

    [Display(Name = "Опис")]
    public string? Description { get; set; } = "Немає опису.";

    [Display(Name = "Кількість оцінок")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Поле має містити тільки цифри.")]
    public int TimesRated { get; set; } = 0;

    [Display(Name = "Середня оцінка")]
    [Range(0, 10, ErrorMessage = "Значення повинно бути в межах від 0 до 10.")]
    public double AverageRating { get; set; } = 0;
}