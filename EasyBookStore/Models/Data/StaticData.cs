using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;

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

        public static List<Author> Authors { get; } = new()
        {
            new Author { Id = 1, Name = "Пушкин", Order = 0 },
            new Author { Id = 2, Name = "Булгаков", Order = 1 },
            new Author { Id = 3, Name = "Чехов", Order = 5 },
            new Author { Id = 4, Name = "Емельянов", Order = 9 },
            new Author { Id = 5, Name = "Иванов", Order = 4 },
            new Author { Id = 6, Name = "Гумилев", Order = 1 },
            new Author { Id = 7, Name = "Козлов", Order = 15 },
            new Author { Id = 8, Name = "Ленин", Order = 9 },
            new Author { Id = 9, Name = "Сталин", Order = 2 },
            new Author { Id = 9, Name = "Пожарский", Order = 3 },
        };

        public static List<Genre> Genres { get; } = new()
        {
            new Genre { Id = 1, Name = "Художественное", Order = 0 },
            new Genre { Id = 2, Name = "Детективы", Order = 1, ParentId = 1 },
            new Genre { Id = 3, Name = "Фантастика", Order = 5, ParentId = 1 },
            new Genre { Id = 4, Name = "Фэнтези", Order = 9, ParentId = 1 },
            new Genre { Id = 5, Name = "Триллер", Order = 11, ParentId = 1 },
            new Genre { Id = 6, Name = "Боевик", Order = 0, ParentId = 1 },
            new Genre { Id = 7, Name = "Ужасы", Order = 20, ParentId = 1 },
            new Genre { Id = 8, Name = "Комедия", Order = 20, ParentId = 1 },
            new Genre { Id = 9, Name = "Мелодрамма", Order = 20, ParentId = 1 },
            new Genre { Id = 10, Name = "Проза", Order = 20, ParentId = 1 },

            new Genre { Id = 11, Name = "Техническое", Order = 20 },
            new Genre { Id = 12, Name = "Компьютеры", Order = 21, ParentId = 11 },
            new Genre { Id = 13, Name = "Строительство", Order = 25, ParentId = 11 },
            new Genre { Id = 14, Name = "Медицина", Order = 20, ParentId = 11 },
            new Genre { Id = 15, Name = "Финансы", Order = 31, ParentId = 11 },

            new Genre { Id = 16, Name = "Общее", Order = 30 },
            new Genre { Id = 17, Name = "Психология", Order = 31, ParentId = 16 },
            new Genre { Id = 18, Name = "Наука", Order = 38, ParentId = 16 },
            new Genre { Id = 19, Name = "Кулинария", Order = 39, ParentId = 16 },
            new Genre { Id = 20, Name = "Самоучители", Order = 37, ParentId = 16 },

            new Genre { Id = 21, Name = "Учебники", Order = 30 },
            new Genre { Id = 22, Name = "Комиксы", Order = 36 },
            new Genre { Id = 23, Name = "Для огорода", Order = 32 },
            new Genre { Id = 24, Name = "Для тёщи", Order = 31 },
            new Genre { Id = 25, Name = "Для детей", Order = 32 },
        };
    }
}
