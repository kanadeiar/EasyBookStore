using EasyBookStore.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Data
{
    public class EasyBookStoreDbInitializer
    {
        private readonly BookStoreContext _context;
        private readonly ILogger<EasyBookStoreDbInitializer> _logger;

        public EasyBookStoreDbInitializer(BookStoreContext context, ILogger<EasyBookStoreDbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary> Инициализация базы данных и заполнение ее тестовыми данными </summary>
        public async Task InitAsync()
        {
            _logger.LogInformation("Starting database initialize");
            //var contextDeleted = await _context.Database.EnsureDeletedAsync();
            //var contextCreated = await _context.Database.EnsureCreatedAsync();

            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();

            if (pendingMigrations.Any())
            {
                _logger.LogInformation($"Applying migrations: {string.Join(",", pendingMigrations)}");
                await _context.Database.MigrateAsync();
            }

            await InitProductsAsync();
        }

        /// <summary> Пересоздание базы данных </summary>
        public EasyBookStoreDbInitializer RecreateDatabase()
        {
            _logger.LogInformation("Recreate database ...");
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            return this;
        }

        private async Task InitProductsAsync()
        {
            var timer = Stopwatch.StartNew();
            if (_context.Genres.Any())
            {
                _logger.LogInformation("Database contains test data - database init with test data is not required");
                return;
            }

            var genresPool = TestData.Genres.ToDictionary(g => g.Id);
            foreach (var child in TestData.Genres.Where(g => g.ParentId is { }))
                child.Parent = genresPool[(int)child.ParentId!];
            var authorsPool = TestData.Authors.ToDictionary(a => a.Id);

            foreach (var product in TestData.Products)
            {
                product.Genre = genresPool[product.GenreId];
                if (product.AuthorId is { } authorId)
                    product.Author = authorsPool[authorId];
                product.Id = 0;
                product.GenreId = 0;
                product.AuthorId = null;
            }
            foreach (var genre in TestData.Genres)
            {
                genre.Id = 0;
                genre.ParentId = null;
            }
            foreach (var author in TestData.Authors)
                author.Id = 0;

            _logger.LogInformation("Writing init data of catalog goods ...");
            await using (await _context.Database.BeginTransactionAsync())
            {
                _context.Genres.AddRange(TestData.Genres);
                _context.Authors.AddRange(TestData.Authors);
                _context.Products.AddRange(TestData.Products);

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            _logger.LogInformation("Complete writing init data of catalog goods");
        }

    }
}
