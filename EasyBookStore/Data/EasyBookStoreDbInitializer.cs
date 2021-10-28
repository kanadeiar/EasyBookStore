using System;
using EasyBookStore.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;
using EasyBookStore.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyBookStore.Data
{
    public class EasyBookStoreDbInitializer
    {
        private readonly BookStoreContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<EasyBookStoreDbInitializer> _logger;

        public EasyBookStoreDbInitializer(
            BookStoreContext context, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<EasyBookStoreDbInitializer> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        /// <summary> Инициализация базы данных и заполнение ее тестовыми данными </summary>
        public async Task InitAsync()
        {
            _logger.LogInformation("Запуск инициализации базы данных");


            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
            var appliedMigrations = await _context.Database.GetAppliedMigrationsAsync();

            if (pendingMigrations.Any())
            {
                _logger.LogInformation($"Применение миграций: {string.Join(",", pendingMigrations)}");
                await _context.Database.MigrateAsync();
            }

            try
            {
                await InitProductsAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка инициализации каталога базы данных");
                throw;
            }

            try
            {
                await InitIdentityAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка инициализации системы идентификации");
                throw;
            }

            try
            {
                await InitWorkersAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка инициализации данных работников");
                throw;
            }
        }

        /// <summary> Пересоздание базы данных </summary>
        public EasyBookStoreDbInitializer RecreateDatabase()
        {
            _logger.LogInformation("Пересоздание базы данных ...");
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();
            return this;
        }
        
        /// <summary> Инициализация каталога базы данных </summary>
        private async Task InitProductsAsync()
        {
            var timer = Stopwatch.StartNew();

            if (_context.Genres.Any())
            {
                _logger.LogInformation("База данных уже содержит тестовые данные - она не требует инициализации");
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

            await using (await _context.Database.BeginTransactionAsync())
            {
                _context.Genres.AddRange(TestData.Genres);
                _context.Authors.AddRange(TestData.Authors);
                _context.Products.AddRange(TestData.Products);

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }

            _logger.LogInformation($"Успешное завершение инициализации базы данных данными каталога товаров за {timer.Elapsed.TotalMilliseconds} мс");
        }

        /// <summary> Инициализация системы идентификации </summary>
        private async Task InitIdentityAsync()
        {
            var timer = Stopwatch.StartNew();

            await CheckRole(Role.Administrators);
            await CheckRole(Role.Users);

            if (await _userManager.FindByNameAsync(User.Administrator) is { })
            {
                _logger.LogInformation("База данных уже содержит идентификационные данные - она не требует инициализации");
                return;
            }

            var admin = new User
            {
                UserName = User.Administrator,
            };

            var result = await _userManager.CreateAsync(admin, User.DefaultAdminPassword);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, Role.Administrators);
                _logger.LogInformation($"Пользователь {admin.UserName} успешно создан и ему назначена роль {Role.Administrators}");
            }
            else
            {
                var errors = result.Errors.Select(err => err.Description).ToArray();
                _logger.LogError($"Учётная запись администратора не создана! Ошибки: {string.Join(", ", errors)}");
                throw new InvalidOperationException($"Невозможно создать Администратора {string.Join(", ", errors)}");
            }

            _logger.LogInformation($"Успешное завершение инициализации системы идентификации за {timer.Elapsed.TotalMilliseconds} мс");

            async Task CheckRole(string role)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    _logger.LogInformation($"Роль {role} уже существует");
                else
                {
                    await _roleManager.CreateAsync(new Role { Name = role });
                    _logger.LogInformation($"Роль {role} успешно создана");
                }
            }
        }

        /// <summary> Инициализация данных работников </summary>
        private async Task InitWorkersAsync()
        {
            var timer = Stopwatch.StartNew();

            if (_context.Workers.Any())
            {
                _logger.LogInformation("База данных уже содержит работников - она не требует инициализации");
                return;
            }

            var workers = TestData.Workers.Select(w => new Worker
            {
                LastName = w.LastName,
                FirstName = w.FirstName,
                Patronymic = w.Patronymic,
                Age = w.Age,
            });

            await using (await _context.Database.BeginTransactionAsync())
            {
                await _context.Workers.AddRangeAsync(workers);

                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }

            _logger.LogInformation($"Успешное завершение инициализации данных работников за {timer.Elapsed.TotalMilliseconds} мс");
        }
    }
}
