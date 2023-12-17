using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Books
{
    public class EditBookModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;

        [BindProperty]
        public Book? inputBook { get; set; }

        public EditBookModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            inputBook = await _service.GetBook(id);
            return inputBook != null ? Page() : Redirect("/");
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (await _service.GetBook(id) is Book book && book != null)
            {
                _service.UpdateBook(inputBook);

                System.Console.WriteLine(inputBook.Id);
                System.Console.WriteLine(id);

                return Redirect("/");
            }

            return NotFound();
        }
    }
}