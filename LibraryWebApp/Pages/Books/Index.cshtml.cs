using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Books
{
    public class BooksIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;
        public List<Book> Books;

        public BooksIndexModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task OnGet()
        {
            Books = (await _service.GetBooks())?.ToList();
        }
    }
}
