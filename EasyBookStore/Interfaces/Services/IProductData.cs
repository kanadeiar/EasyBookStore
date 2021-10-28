using System.Collections.Generic;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using Microsoft.VisualBasic;

namespace EasyBookStore.Interfaces.Services
{
    public interface IProductData
    {
        /// <summary> Получить жанры книг </summary>
        IEnumerable<Genre> GetGenres();
        /// <summary> Получить жанр книги </summary>
        Genre GetGenre(int id);
        /// <summary> Получить жанры книг с товарами </summary>
        IEnumerable<Genre> GetGenresWithProducts();
        /// <summary> Получить авторов книг </summary>
        IEnumerable<Author> GetAuthors();
        /// <summary> Получить одного автора </summary>
        Author GetAuthor(int id);
        /// <summary> Получить авторов книг с товарами </summary>
        IEnumerable<Author> GetAuthorsWithProducts();
        /// <summary> Получить товары-книги </summary>
        public IEnumerable<Product> GetProducts(ProductFilter filter = null);
        /// <summary> Получить один товар-книгу </summary>
        Product GetProduct(int id);
    }
}
