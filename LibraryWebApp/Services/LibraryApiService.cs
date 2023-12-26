using System.Text.Json;
using LibraryAPI.Models;

namespace LibraryWebApp.Services;

public class LibraryApiService
{
    const string ApiURI = "http://localhost:5063";
    private HttpClient _client;
    public LibraryApiService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient();
    }

    public async Task<IEnumerable<Book>?> GetBooks()
    {
        var response = await _client.GetAsync(ApiURI + "/Books");

        if (response.IsSuccessStatusCode)
        {
            var books = await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();

            return books;
        }

        return Enumerable.Empty<Book>();
    }

    public async Task<IEnumerable<Article>?> GetArticles()
    {
        var response = await _client.GetAsync(ApiURI + "/Articles");

        if (response.IsSuccessStatusCode)
        {
            var articles = await response.Content.ReadFromJsonAsync<IEnumerable<Article>>();

            return articles;
        }

        return Enumerable.Empty<Article>();
    }

    public async Task<Book?> GetBook(int id)
    {
        var response = await _client.GetAsync(ApiURI + $"/Books/{id}");

        if (response.IsSuccessStatusCode)
        {
            var book = await response.Content.ReadFromJsonAsync<Book>();

            return book;
        }

        return null;
    }

    public async Task<Article?> GetArticle(int id)
    {
        var response = await _client.GetAsync(ApiURI + $"/Articles/{id}");

        if (response.IsSuccessStatusCode)
        {
            var article = await response.Content.ReadFromJsonAsync<Article>();

            return article;
        }

        return null;
    }

    public async Task DeleteBook(int id)
    {
        await _client.DeleteAsync(ApiURI + $"/Books/{id}");
    }

    public async Task DeleteArticle(int id)
    {
        await _client.DeleteAsync(ApiURI + $"/Articles/{id}");
    }

    public async Task CreateBook(Book book)
    {
        await _client.PostAsJsonAsync(ApiURI + $"/Books/", book);
    }

    public async Task CreateArticle(Article article)
    {
        await _client.PostAsJsonAsync(ApiURI + $"/Articles/", article);
    }

    public void UpdateBook(Book book)
    {
        _client.PutAsJsonAsync(ApiURI + $"/Book/{book.Id}", book);
    }

    public void UpdateArticle(Article article)
    {
        _client.PutAsJsonAsync(ApiURI + $"/Articles/{article.Id}", article);
    }
}