using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Models.Data
{
    public class StaticData
    {
        public static List<Worker> GetWorkers => Enumerable.Range(1, 30).Select(p => new Worker
        {
            Id = p,
            FirstName = $"Иван {p}",
            LastName = $"Иванов {p}",
            Patronymic = $"Иванович {p}",
            Age = p + 18,
        }).ToList();
    }
}
