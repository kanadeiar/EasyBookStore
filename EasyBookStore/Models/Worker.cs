using System.Collections.Generic;
using System.Linq;
using EasyBookStore.Models.Base;

namespace EasyBookStore.Models
{
    public class Worker : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

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
