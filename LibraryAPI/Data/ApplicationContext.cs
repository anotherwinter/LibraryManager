using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options) { }

    public DbSet<Book> Books {get; set;}
    public DbSet<Article> Articles {get; set;}
}