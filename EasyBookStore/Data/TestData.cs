using EasyBookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.Data
{
    public static class TestData
    {
        private static Random __rand = new Random();
        private static string[] _firstNames = { "Иван", "Василий", "Петр" };
        private static string[] _lastNames = { "Иванов", "Васильев", "Петров" };
        private static string[] _patronymicNames = { "Иванович", "Васильевич", "Петрович" };

        public static List<Worker> Workers => Enumerable.Range(1, 10).Select(p => new Worker
        {
            Id = p,
            FirstName = _firstNames[__rand.Next(_firstNames.Count())],
            LastName = _lastNames[__rand.Next(_lastNames.Count())],
            Patronymic = _patronymicNames[__rand.Next(_patronymicNames.Count())],
            Age = __rand.Next(18, 50),
        }).ToList();

        public static List<Author> Authors { get; } = new()
        {
            new Author { Id = 1, Name = "А.С. Пушкин", Order = 0 },
            new Author { Id = 2, Name = "М.С. Булгаков", Order = 1 },
            new Author { Id = 3, Name = "М.А. Чехов", Order = 5 },
            new Author { Id = 4, Name = "А.А. Емельянов", Order = 9 },
            new Author { Id = 5, Name = "И.И. Иванов", Order = 4 },
            new Author { Id = 6, Name = "Г.А. Гумилев", Order = 1 },
            new Author { Id = 7, Name = "К.О. Козлов", Order = 15 },
            new Author { Id = 8, Name = "И.О. Ленин", Order = 9 },
            new Author { Id = 9, Name = "И.В. Сталин", Order = 2 },
            new Author { Id = 10, Name = "Ф.У. Пожарский", Order = 12 },
        };

        public static List<Genre> Genres { get; } = new()
        {
            new Genre { Id = 1, Name = "Художественное", Order = 0 },
            new Genre { Id = 2, Name = "Детектив", Order = 1, ParentId = 1 },
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

            new Genre { Id = 21, Name = "Учебники", Order = 38 },
            new Genre { Id = 22, Name = "Комиксы", Order = 36 },
            new Genre { Id = 23, Name = "Огород", Order = 32 },
            new Genre { Id = 24, Name = "Иностранное", Order = 31 },
            new Genre { Id = 25, Name = "Детское", Order = 32 },
        };

        public static List<Product> Products { get; } = new()
        {
            new Product { Id = 1, Name = "Гарри поттер 1", Price = 500, ImageUrl = "harrypotter1.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 0, AuthorId = 1, GenreId = 3 },
            new Product { Id = 2, Name = "Гарри поттер 2", Price = 450, ImageUrl = "harrypotter2.png", Message = "Продолжение похождений Гарри Поттера по фантастическим местам.", Order = 1, AuthorId = 1, GenreId = 3 },
            new Product { Id = 3, Name = "Гарри поттер 3", Price = 800, ImageUrl = "harrypotter3.png", Message = "Заключительная часть цикла Гарии Поттера рассказывает о его победах.", Order = 2, AuthorId = 1, GenreId = 4 },
            new Product { Id = 4, Name = "Властелин колец 1", Price = 600, ImageUrl = "lordofrings1.png", Message = "Первая замечательная книга о похождения хранителя колец и его спутников.", Order = 3, AuthorId = 2, GenreId = 2 },
            new Product { Id = 5, Name = "Властелин колец 2", Price = 790, ImageUrl = "lordofrings2.png", Message = "Продолжение похождения хранителей колец и их врагов по Средиземью.", Order = 4, AuthorId = 2, GenreId = 5 },
            new Product { Id = 6, Name = "Властелин колец 3", Price = 400, ImageUrl = "lordofrings3.png", Message = "Продолжение похождений геров хранителей колец по Средиземью и окрестностям.", Order = 5, AuthorId = 2, GenreId = 6 },
            new Product { Id = 7, Name = "Путешествие", Price = 510, ImageUrl = "worldtravel.png", Message = "Книга о мировом путешествии странника через каждый город поочередно.", Order = 6, AuthorId = 3, GenreId = 10 },
            new Product { Id = 8, Name = "Гении и трусы", Price = 400, ImageUrl = "genius.png", Message = "Книга о противостоянии гениев и трусов в отдельно взятой комнате квартиры.", Order = 7, AuthorId = 1, GenreId = 7 },
            new Product { Id = 9, Name = "Синяя книга", Price = 790, ImageUrl = "bluebook.png", Message = "Книга о синем цвете, его назначении, применении, технических требованиях и прочем.", Order = 8, AuthorId = 4, GenreId = 8 },
            new Product { Id = 10, Name = "Триумф в сортире", Price = 920, ImageUrl = "toilet.png", Message = "Книга о капитальном ремонте сантехники в ограниченном пространстве.", Order = 9, AuthorId = 5, GenreId = 9 },
            new Product { Id = 11, Name = "Терминатор 1", Price = 300, ImageUrl = "terminator1.png", Message = "Книга о приключениях молодога терминатора в фантастическом мире в окружении врагов.", Order = 10, AuthorId = 6, GenreId = 12 },
            new Product { Id = 12, Name = "Терминатор 2", Price = 750, ImageUrl = "terminator2.png", Message = "Продолжение приключений молодого терминатора в фэнтезийном мире в окружении фей.", Order = 11, AuthorId = 6, GenreId = 13 },
            new Product { Id = 13, Name = "Терминатор 3", Price = 800, ImageUrl = "terminator3.png", Message = "Заключительная часть приключений молодого терминатора в ужасном мире чебурашек.", Order = 12, AuthorId = 6, GenreId = 14 },
            new Product { Id = 14, Name = "Начальник 1", Price = 880, ImageUrl = "boss1.png", Message = "Книга о криках, воплях и истериках начальника завода в процессе управления работниками.", Order = 13, AuthorId = 7, GenreId = 15 },
            new Product { Id = 15, Name = "Начальник 2", Price = 990, ImageUrl = "boss2.png", Message = "Продолжение ужасных криков, воплей и истерик начальника завода уже без работников.", Order = 14, AuthorId = 7, GenreId = 17 },
            new Product { Id = 16, Name = "Буржуи 1", Price = 1400, ImageUrl = "bourgeois1.png", Message = "Книга о буржуях отдельно взятой капиталистической страны в условиях кризиса.", Order = 15, AuthorId = 8, GenreId = 22 },
            new Product { Id = 17, Name = "Информатика", Price = 910, ImageUrl = "informatics.png", Message = "Книга о компьютерах и приемах работы с ними на примере стандартного персонального компьютера.", Order = 16, AuthorId = 9, GenreId = 21 },
            new Product { Id = 18, Name = "Компьютерные вирусы", Price = 900, ImageUrl = "viruses.png", Message = "Книга о компьютерных вирусах и вредоносных опасных программах.", Order = 17, AuthorId = 10, GenreId = 17 },
            new Product { Id = 19, Name = "Шесть соток", Price = 1190, ImageUrl = "sixhome.png", Message = "Книга о увлекательных развлечениях на дачном участке размером в шесть соток.", Order = 18, AuthorId = 9, GenreId = 23 },
            new Product { Id = 20, Name = "Сказки на ночь", Price = 1220, ImageUrl = "tales.png", Message = "Книга о Гарри поттере первая из всего цикла рассказывает о фантастике.", Order = 19, AuthorId = 10, GenreId = 25 },
            new Product { Id = 21, Name = "Игры престолов 1", Price = 300, ImageUrl = "games1.png", Message = "Книга о игре престолов в на территории отдельного взятого острова в условиях конфликтов.", Order = 20, AuthorId = 5, GenreId = 17 },
            new Product { Id = 22, Name = "Игры престолов 2", Price = 750, ImageUrl = "games2.png", Message = "Продолжение книги о игре престолов на территории того-же самого отсрова.", Order = 2, AuthorId = 5, GenreId = 18 },
            new Product { Id = 23, Name = "Игры престолов 3", Price = 800, ImageUrl = "games3.png", Message = "Еще следущее продолжение книги о игре престолов на территории того-же самого острова.", Order = 4, AuthorId = 5, GenreId = 19 },
            new Product { Id = 24, Name = "Игры престолов 4", Price = 880, ImageUrl = "games4.png", Message = "Заключительная книга о игре престолов на территории того-же самого острова.", Order = 23, AuthorId = 5, GenreId = 20 },
            new Product { Id = 25, Name = "Олигархи", Price = 990, ImageUrl = "oligarches.png", Message = "Книга о олигархах в условиях жесткой конкуренции и ограниченном пространстве.", Order = 24, AuthorId = 7, GenreId = 17 },
            new Product { Id = 26, Name = "Буржуи 2", Price = 1400, ImageUrl = "bourgeois2.png", Message = "Продолжение книги о буржуях отдельно взятой капиталистической страны в условиях кризиса.", Order = 25, AuthorId = 8, GenreId = 22 },
            new Product { Id = 27, Name = "Программирование", Price = 910, ImageUrl = "programming.png", Message = "Книга о программировании обычных компьютерных программ и отладке багов в этих программах.", Order = 26, AuthorId = 9, GenreId = 21 },
            new Product { Id = 28, Name = "Magic", Price = 900, ImageUrl = "magic.png", Message = "This book of the magic in a new fantastic world with a lot of heroes.", Order = 27, AuthorId = 10, GenreId = 24 },
            new Product { Id = 29, Name = "Ужасы детям", Price = 1190, ImageUrl = "horrors.png", Message = "Книга о страшных ужасах маленьких детей предназначена для чтения на ночь.", Order = 28, AuthorId = 9, GenreId = 25 },
            new Product { Id = 30, Name = "Букварь", Price = 1220, ImageUrl = "primer.png", Message = "Книга начальных знаний детей об алфавите на начальных стадиях обучения.", Order = 0, AuthorId = 10, GenreId = 25 },
        };

    }
}
