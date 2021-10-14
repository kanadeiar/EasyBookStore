using EasyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Interfaces.Services
{
    public interface IWorkerData
    {
        Task<IEnumerable<Worker>> GetAll();
        Task<Worker> Get(int id);
        Task<int> Add(Worker worker);
        Task Update(Worker worker);
        Task<bool> Delete(int id);
    }
}
