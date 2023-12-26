using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Articles
{
    public class AddArticleModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;

        [BindProperty]
        public Article? InputArticle { get; set; }

        public AddArticleModel(ILogger<IndexModel> logger, LibraryApiService service)
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
            if (ModelState.IsValid)
            {
                InputArticle.Date = DateOnly.FromDateTime(DateTime.Now);

                await _service.CreateArticle(InputArticle);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}