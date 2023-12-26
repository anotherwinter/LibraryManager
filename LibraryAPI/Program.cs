using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    })
);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapGet("/Books", GetBooks)
    .WithName("GetBooks")
    .WithOpenApi();

app.MapGet("/Articles", GetArticles)
    .WithName("GetArticles")
    .WithOpenApi();

app.MapGet("/Books/{id}", GetBook)
    .WithName("GetBook")
    .WithOpenApi();

app.MapGet("/Articles/{id}", GetArticle)
    .WithName("GetArticle")
    .WithOpenApi();

app.MapPost("/Books/", PostBook)
    .WithName("PostBook")
    .WithOpenApi();

app.MapPost("/Articles/", PostArticle)
    .WithName("PostArticle")
    .WithOpenApi();

app.MapPut("/Book/{id}", UpdateBook)
    .WithName("UpdateBook")
    .WithOpenApi();

app.MapPut("/Article/{id}", UpdateArticle)
    .WithName("UpdateArticle")
    .WithOpenApi();

app.MapDelete("/Books/{id}", DeleteBook)
    .WithName("DeleteBook")
    .WithOpenApi();

app.MapDelete("/Articles/{id}", DeleteArticle)
    .WithName("DeleteArticle")
    .WithOpenApi();

app.Run();

async Task<IResult> GetBooks(ApplicationContext context)
{
    var books = await context.Books.ToListAsync();
    return TypedResults.Ok(books);
}

async Task<IResult> GetArticles(ApplicationContext context)
{
    var articles = await context.Articles.ToListAsync();
    return TypedResults.Ok(articles);
}

async Task<IResult> GetBook(ApplicationContext context, int id) =>
    await context.Books.FindAsync(id) is Book book ? TypedResults.Ok(book) : TypedResults.NotFound();

async Task<IResult> GetArticle(ApplicationContext context, int id) =>
    await context.Articles.FindAsync(id) is Article article ? TypedResults.Ok(article) : TypedResults.NotFound();


async Task<IResult> PostBook(ApplicationContext context, Book book)
{
    context.Books.Add(book);
    await context.SaveChangesAsync();

    return TypedResults.Created($"/Books/{book.Id}", book);
}

async Task<IResult> PostArticle(ApplicationContext context, Article article)
{
    context.Articles.Add(article);
    await context.SaveChangesAsync();
    return TypedResults.Created($"/Articles/{article.Id}", article);
}

async Task<IResult> UpdateBook(ApplicationContext context, int id, Book inputBook)
{
    var book = await context.Books.FindAsync(id);

    if (book is null) return TypedResults.NotFound();

    book.UpdateInstance(inputBook);

    await context.SaveChangesAsync();

    return TypedResults.Ok();
}

async Task<IResult> UpdateArticle(ApplicationContext context, int id, Article inputArticle)
{
    var article = await context.Articles.FindAsync(id);

    if (article is null) return TypedResults.NotFound();

    article.UpdateInstance(inputArticle);

    await context.SaveChangesAsync();

    return TypedResults.Ok();
}

async Task<IResult> DeleteBook(ApplicationContext context, int id)
{
    if (await context.Books.FindAsync(id) is Book book && book != null)
    {
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}

async Task<IResult> DeleteArticle(ApplicationContext context, int id)
{
    if (await context.Articles.FindAsync(id) is Article article && article != null)
    {
        context.Articles.Remove(article);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}
