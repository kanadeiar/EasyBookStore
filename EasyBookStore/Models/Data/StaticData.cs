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
            new Author { Id = 10, Name = "Пожарский", Order = 12 },
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

        public static List<Product> Products { get; } = new()
        {
            new Product { Id = 1, Name = "Гарри поттер 1", Price = 500, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 0, AuthorId = 1, GenreId = 3 },
            new Product { Id = 2, Name = "Гарри поттер 2", Price = 450, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 1, AuthorId = 1, GenreId = 3 },
            new Product { Id = 3, Name = "Гарри поттер 3", Price = 800, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 2, AuthorId = 1, GenreId = 4 },
            new Product { Id = 4, Name = "Властелин колец 1", Price = 600, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 3, AuthorId = 2, GenreId = 4 },
            new Product { Id = 5, Name = "Властелин колец 2", Price = 790, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 4, AuthorId = 2, GenreId = 5 },
            new Product { Id = 6, Name = "Властелин колец 3", Price = 400, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 5, AuthorId = 2, GenreId = 6 },
            new Product { Id = 7, Name = "Путешествие по миру", Price = 510, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 6, AuthorId = 3, GenreId = 10 },
            new Product { Id = 8, Name = "Гении и трусы", Price = 400, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 7, AuthorId = 1, GenreId = 7 },
            new Product { Id = 9, Name = "Синяя книга", Price = 790, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 8, AuthorId = 4, GenreId = 8 },
            new Product { Id = 10, Name = "Триумф в сортире", Price = 920, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 9, AuthorId = 5, GenreId = 9 },
            new Product { Id = 11, Name = "Терминатор 1", Price = 300, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 10, AuthorId = 6, GenreId = 12 },
            new Product { Id = 12, Name = "Терминатор 2", Price = 750, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 11, AuthorId = 6, GenreId = 13 },
            new Product { Id = 13, Name = "Терминатор 3", Price = 800, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 12, AuthorId = 6, GenreId = 14 },
            new Product { Id = 14, Name = "Буржуазия 1", Price = 700, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 13, AuthorId = 7, GenreId = 15 },
            new Product { Id = 15, Name = "Буржуазия 2", Price = 990, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 14, AuthorId = 7, GenreId = 17 },
            new Product { Id = 16, Name = "Буржуи", Price = 1400, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 15, AuthorId = 8, GenreId = 21 },
            new Product { Id = 17, Name = "Филькина грамота", Price = 910, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 16, AuthorId = 9, GenreId = 22 },
            new Product { Id = 18, Name = "Компьютерные вирусы", Price = 900, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 17, AuthorId = 10, GenreId = 24 },
            new Product { Id = 19, Name = "Шесть соток", Price = 1190, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 18, AuthorId = 9, GenreId = 23 },
            new Product { Id = 20, Name = "Сказки на ночь", Price = 1220, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 19, AuthorId = 10, GenreId = 25 },
        };
    }
}
