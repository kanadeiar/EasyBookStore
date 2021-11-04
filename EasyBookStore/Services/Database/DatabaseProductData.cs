using System;
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

        public async Task<IEnumerable<Product>> GetProductsAsync(ProductFilter filter = null, bool includes = false)
        {
            IQueryable<Product> query = (includes)
               ? _context.Products
                   .Include(p => p.Genre)
                   .Include(p => p.Author)
                   .Where(p => !p.IsDelete)
               : _context.Products
                   .Where(p => !p.IsDelete);

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

        public async Task<int> AddProductAsync(Product product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            _context.Add(product);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return product.Id;
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));
            if (_context.Products.Local.Any(e => e == product) == false)
            {
                var origin = await _context.Products.FindAsync(product.Id).ConfigureAwait(false);
                origin.Name = product.Name;
                origin.Order = product.Order;
                origin.GenreId = product.GenreId;
                origin.AuthorId = product.AuthorId;
                origin.ImageUrl = product.ImageUrl;
                origin.Price = product.Price;
                origin.Message = product.Message;
                _context.Update(origin);
            }
            else
                _context.Update(product);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if (await GetProductAsync(id).ConfigureAwait(false) is { } product)
                product.IsDelete = true;
            else
                return false;
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Товар {id} {product.Name} успешно помечен удаленным из базы данных");
            return true;
        }
    }
}
