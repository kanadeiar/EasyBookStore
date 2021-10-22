using EasyBookStore.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            if (_context.Genres.Any())
            {
                _logger.LogInformation("Database contains test data - database init with test data is not required");
                return;
            }

            _logger.LogInformation("Writing genres of books ...");
            await using (await _context.Database.BeginTransactionAsync())
            {
                _context.Genres.AddRange(TestData.Genres);

                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Genres] ON");
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Genres] OFF");
                await _context.Database.CommitTransactionAsync();
            }
            _logger.LogInformation("Writing authors of books ...");
            await using (await _context.Database.BeginTransactionAsync())
            {
                _context.Authors.AddRange(TestData.Authors);

                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Authors] ON");
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Authors] OFF");
                await _context.Database.CommitTransactionAsync();
            }
            _logger.LogInformation("Writing goods books ...");
            await using (await _context.Database.BeginTransactionAsync())
            {
                _context.Products.AddRange(TestData.Products);

                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] ON");
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] OFF");
                await _context.Database.CommitTransactionAsync();
            }
        }

    }
}
