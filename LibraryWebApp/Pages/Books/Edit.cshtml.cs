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
        public Book? InputBook { get; set; }

        public EditBookModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            InputBook = await _service.GetBook(id);
            return InputBook != null ? Page() : NotFound();
        }

        public IActionResult OnPost(int id)
        {
            if (id != InputBook!.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.UpdateBook(InputBook);

                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (await _service.GetBook(id) is Book book && book != null)
            {
                await _service.DeleteBook(id);

                return RedirectToPage("/Index");
            }

            return NotFound();
        }
    }
}