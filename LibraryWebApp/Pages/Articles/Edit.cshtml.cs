using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Articles
{
    public class EditArticleModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;

        [BindProperty]
        public Article? InputArticle { get; set; }

        public EditArticleModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            InputArticle = await _service.GetArticle(id);
            return InputArticle != null ? Page() : NotFound();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (await _service.GetArticle(id) is Article article && article != null)
            {
                _service.UpdateArticle(InputArticle);

                return Redirect("/Index");
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (await _service.GetArticle(id) is Article article && article != null)
            {
                await _service.DeleteArticle(id);

                return Redirect("/Index");
            }

            return NotFound();
        }
    }
}