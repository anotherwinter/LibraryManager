using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages;

public class SearchModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LibraryApiService _service;
    public ApplicationViewModel _viewModel = new();
    public string SearchString { get; set; }

    public SearchModel(ILogger<IndexModel> logger, LibraryApiService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> OnGet(string type, string searchString)
    {
        if (type != "Article" && type != "Book") return NotFound();

        if (type == "Book") _viewModel.Books = (await _service.GetBooks())?.Where(b => b.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
        else _viewModel.Articles = (await _service.GetArticles())?.Where(a => a.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        SearchString = searchString;

        return Page();
    }
}
