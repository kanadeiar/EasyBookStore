using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Dal.Context;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyBookStore.Services.Database
{
    public class DatabaseWorkerData : IWorkerData
    {
        private readonly BookStoreContext _context;
        private readonly ILogger<DatabaseWorkerData> _logger;
        public DatabaseWorkerData(BookStoreContext context, ILogger<DatabaseWorkerData> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Worker>> GetAll()
        {
            return await _context.Workers.ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<Worker> Get(int id)
        {
            return await _context.Workers.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<int> Add(Worker worker)
        {
            if (worker is null)
                throw new ArgumentNullException(nameof(worker));
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return worker.Id;
        }

        public async Task Update(Worker worker)
        {
            if (worker is null)
                throw new ArgumentNullException(nameof(worker));
            if (_context.Workers.Local.Any(e => e == worker) == false)
            {
                var origin = await _context.Workers.FindAsync(worker.Id).ConfigureAwait(false);
                origin.LastName = worker.LastName;
                origin.FirstName = worker.FirstName;
                origin.Patronymic = worker.Patronymic;
                origin.Age = worker.Age;
                _context.Update(origin);
            }
            else
                _context.Update(worker);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> Delete(int id)
        {
            if (await Get(id) is not { } item)
                return false;
            _context.Workers.Remove(item);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }
}
