using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Books
{
    public class BookDetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;
        public Book? book;

        public BookDetailsModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            book = await _service.GetBook(id);
            return book != null ? Page() : NotFound();
        }
    }
}
