using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryWebApp.Pages.Shared
{
    public class SearchBarModel : PageModel
    {
        public string? Type { get; set; }
        public string? SearchString { get; set; }
            public SelectList Types { get; } = new SelectList(new List<SelectListItem>
    {
        new SelectListItem { Value = "Book", Text = "Книга" },
        new SelectListItem { Value = "Article", Text = "Стаття" }
    }, "Value", "Text");
    }
}
