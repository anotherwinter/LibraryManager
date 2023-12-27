namespace LibraryAPI.Models;

public class ApplicationViewModel
{
    public List<Book>? Books = [];
    public List<Article>? Articles = [];

    public bool IsEmpty()
    {
        return Books?.Count == 0 && Articles?.Count == 0 ? true : false;
    }
}