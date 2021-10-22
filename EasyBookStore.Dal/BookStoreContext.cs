using EasyBookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyBookStore.Dal
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Product> Products { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

    }
}
