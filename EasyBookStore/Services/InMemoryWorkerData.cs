using EasyBookStore.Interfaces.Services;
using EasyBookStore.Models;
using EasyBookStore.Models.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Services
{
    public class InMemoryWorkerData : IWorkerData
    {
        private readonly ILogger<InMemoryWorkerData> _logger;
        private readonly IList<Worker> _workers = StaticData.GetWorkers;
        private int _currentMaxId;
        public InMemoryWorkerData(ILogger<InMemoryWorkerData> logger)
        {
            _logger = logger;
            _currentMaxId = _workers.Max(e => e.Id);
        }

        public Task<IEnumerable<Worker>> GetAll()
        {
            return Task.FromResult<IEnumerable<Worker>>(_workers);
        }

        public Task<Worker> Get(int id)
        {
            var worker = _workers.SingleOrDefault(w => w.Id == id);
            return Task.FromResult(worker);
        }

        public Task<int> Add(Worker worker)
        {
            if (worker is null) throw new ArgumentNullException(nameof(worker));
            if (_workers.Contains(worker)) return Task.FromResult(worker.Id);

            worker.Id = ++_currentMaxId;

            _workers.Add(worker);

            return Task.FromResult(worker.Id);
        }

        public async Task Update(Worker worker)
        {
            if (worker is null) throw new ArgumentNullException(nameof(worker));

            if (_workers.Contains(worker)) return;

            var editWorker = await Get(worker.Id);
            if (editWorker is null) return;

            editWorker.FirstName = worker.FirstName;
            editWorker.LastName = worker.LastName;
            editWorker.Patronymic = worker.Patronymic;
            editWorker.Age = worker.Age;
        }

        public async Task<bool> Delete(int id)
        {
            var delWorker = await Get(id);
            if (delWorker is null) return false;

            _workers.Remove(delWorker);

            return true;
        }






    }
}
