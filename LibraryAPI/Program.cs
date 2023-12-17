using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/Books", async (ApplicationContext context) =>
    {
        var books = await context.Books.ToListAsync();
        return Results.Ok(books);
    })
    .WithName("GetBooks")
    .WithOpenApi();

app.MapGet("/Articles", async (ApplicationContext context) =>
    {
        var articles = await context.Articles.ToListAsync();
        return Results.Ok(articles);
    })
    .WithName("GetArticles")
    .WithOpenApi();

app.MapGet("/Books/{id}", async (ApplicationContext context, int id) =>
    await context.Books.FindAsync(id) is Book book ? Results.Ok(book) : Results.NotFound())
    .WithName("GetBook")
    .WithOpenApi();

app.MapGet("/Articles/{id}", async (ApplicationContext context, int id) =>
    await context.Articles.FindAsync(id) is Article article ? Results.Ok(article) : Results.NotFound())
    .WithName("GetArticle")
    .WithOpenApi();

app.MapPost("/Books/", async (ApplicationContext context, Book book) =>
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return Results.Created($"/Books/{book.Id}", book);
    })
    .WithName("PostBook")
    .WithOpenApi();

app.MapPost("/Articles/", async (ApplicationContext context, Article article) =>
    {
        context.Articles.Add(article);
        await context.SaveChangesAsync();
        return Results.Created($"/Articles/{article.Id}", article);
    })
    .WithName("PostArticle")
    .WithOpenApi();

app.MapPut("/Book/{id}", async (ApplicationContext context, int id, Book inputBook) =>
    {
        var book = await context.Books.FindAsync(id);

        if (book is null) return Results.NotFound();

        book.UpdateInstance(inputBook);

        await context.SaveChangesAsync();

        return Results.Ok();
    })
    .WithName("UpdateBook")
    .WithOpenApi();

app.MapPut("/Article/{id}", async (ApplicationContext context, int id, Article inputArticle) =>
    {
        var article = await context.Articles.FindAsync(id);

        if (article is null) return Results.NotFound();

        article.UpdateInstance(inputArticle);

        await context.SaveChangesAsync();

        return Results.Ok();
    })
    .WithName("UpdateArticle")
    .WithOpenApi();

app.MapDelete("/Books/{id}", async (ApplicationContext context, int id) =>
    {
        if (await context.Books.FindAsync(id) is Book book)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        return Results.NotFound();
    })
    .WithName("DeleteBook")
    .WithOpenApi();

app.MapDelete("/Articles/{id}", async (ApplicationContext context, int id) =>
    {
        if (await context.Articles.FindAsync(id) is Article article)
        {
            context.Articles.Remove(article);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        return Results.NotFound();
    })
    .WithName("DeleteArticle")
    .WithOpenApi();

app.Run();
