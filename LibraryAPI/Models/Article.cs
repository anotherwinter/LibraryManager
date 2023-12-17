using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models;

[PrimaryKey("Id")]
public class Article : IUpdatable<Article>
{
    [Column("article_id"), Key]
    public int Id { get; }

    [Column("article_title")]
    public string Title { get; set; } = null!;

    [Column("article_date")]
    public DateOnly Date { get; set; }

    [Column("article_text")]
    public string? Text { get; set; }

    public void UpdateInstance(Article input)
    {
        Title = input.Title;
        Date = input.Date;
        Text = input.Text;
    }
}