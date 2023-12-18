using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    [JsonConverter(typeof(DateOnlyJsonConverter))]
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

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}