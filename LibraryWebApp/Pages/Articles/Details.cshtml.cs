using LibraryAPI.Models;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWebApp.Pages.Articles
{
    public class ArticleDetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LibraryApiService _service;
        public Article? article;

        public ArticleDetailsModel(ILogger<IndexModel> logger, LibraryApiService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            article = await _service.GetArticle(id);
            return article != null ? Page() : NotFound();
        }
    }
}
