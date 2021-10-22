using EasyBookStore.Dal;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace EasyBookStore.Services.Database
{
    public class DatabaseProductData : IProductData
    {
        private readonly BookStoreContext _context;
        public DatabaseProductData(BookStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Genre> GetGenres() => _context.Genres;
        public IEnumerable<Author> GetAuthors() => _context.Authors;


        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = _context.Products;

            if (filter?.GenreId is { } genre)
                query = query.Where(p => p.GenreId == genre);

            if (filter?.AuthorId is { } author)
                query = query.Where(p => p.AuthorId == author);

            return query;
        }
    }
}
