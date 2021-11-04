using System.Collections.Generic;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;

namespace EasyBookStore.Interfaces.Services
{
    /// <summary> Данные по работникам </summary>
    public interface IWorkerData
    {
        /// <summary> Данные по всем работникам </summary>
        Task<IEnumerable<Worker>> GetAll();
        /// <summary> Получить одного работника </summary>
        Task<Worker> Get(int id);
        /// <summary> Добавить одного работника </summary>
        Task<int> Add(Worker worker);
        /// <summary> Обновить одного работника </summary>
        Task Update(Worker worker);
        /// <summary> Удалить одного рбаотника </summary>
        Task<bool> Delete(int id);
    }
}
