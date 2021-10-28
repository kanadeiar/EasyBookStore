using EasyBookStore.Dal.Context;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genres.Include(g => g.Products).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<Genre> GetGenreAsync(int id)
        {
            return await _context.Genres.Include(g => g.Products).SingleOrDefaultAsync(g => g.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Products).ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _context.Authors.Include(a => a.Products).SingleOrDefaultAsync(a => a.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(ProductFilter filter = null)
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

            return await query.ToArrayAsync().ConfigureAwait(false);
        }
        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Genre)
                .Include(p => p.Author)
                .SingleOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
        }
    }
}
