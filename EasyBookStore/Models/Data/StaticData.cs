using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Models.Data
{
    public class StaticData
    {
        private static Random __rand = new Random();
        private static string[] _firstNames = { "Иван", "Василий", "Петр"};
        private static string[] _lastNames = { "Иванов", "Васильев", "Петров" };
        private static string[] _patronymicNames = { "Иванович", "Васильевич", "Петрович" };

        public static List<Worker> GetWorkers => Enumerable.Range(1, 10).Select(p => new Worker
        {
            Id = p,
            FirstName = _firstNames[__rand.Next(_firstNames.Count())],
            LastName = _lastNames[__rand.Next(_lastNames.Count())],
            Patronymic = _patronymicNames[__rand.Next(_patronymicNames.Count())],
            Age = __rand.Next(18, 50),
        }).ToList();
    }
}
