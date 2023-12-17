using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace LibraryWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LibraryApiService _service;
    public ApplicationViewModel _viewModel = new();

    public IndexModel(ILogger<IndexModel> logger, LibraryApiService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task OnGet()
    {
        _viewModel.Books = (await _service.GetBooks())?.ToList();
        _viewModel.Articles = (await _service.GetArticles())?.ToList();
    }
}
