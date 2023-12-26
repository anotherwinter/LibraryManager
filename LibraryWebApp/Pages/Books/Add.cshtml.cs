using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Books
{
    public class AddBookModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;

        [BindProperty]
        public Book? inputBook { get; set; }

        public AddBookModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await _service.CreateBook(inputBook);

            return RedirectToPage("/Index");
        }
    }
}