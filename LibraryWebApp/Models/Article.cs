using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models;

public class Article
{
    public int Id { get; set; }

    [Display(Name = "Назва")]
    [StringLength(50, ErrorMessage = "Назва не має бути довшою за 50 символів.")]
    public string Title { get; set; } = null!;

    public DateOnly Date { get; set; }

    [Display(Name = "Текст")]
    public string? Text { get; set; } = "Немає опису.";
}