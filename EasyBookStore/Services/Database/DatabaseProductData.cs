using EasyBookStore.Dal.Context;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace EasyBookStore.Services.Database
{
    public class DatabaseProductData : IProductData
    {
        private readonly BookStoreContext _context;
        private readonly ILogger<DatabaseProductData> _logger;

        public DatabaseProductData(BookStoreContext context, ILogger<DatabaseProductData> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres;
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres.SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Genre> GetGenresWithProducts()
        {
            return _context.Genres.Include(g => g.Products);
        }
        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors;
        }

        public Author GetAuthor(int id)
        {
            return _context.Authors.SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAuthorsWithProducts()
        {
            return _context.Authors.Include(a => a.Products);
        }
        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Genre)
                .Include(p => p.Author);

            if (filter?.Ids?.Length > 0)
            {
                query = query.Where(p => filter.Ids.Contains(p.Id));
            }
            else
            {
                if (filter?.GenreId is { } genre)
                    query = query.Where(p => p.GenreId == genre);

                if (filter?.AuthorId is { } author)
                    query = query.Where(p => p.AuthorId == author);
            }
            _logger.LogInformation($"SQL: {query.ToQueryString()}");
            return query;
        }

        public Product GetProduct(int id)
        {
            return _context.Products
                .Include(p => p.Genre)
                .Include(p => p.Author)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
