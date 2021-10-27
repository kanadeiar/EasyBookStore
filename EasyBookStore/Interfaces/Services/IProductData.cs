using System.Collections.Generic;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;

namespace EasyBookStore.Interfaces.Services
{
    public interface IProductData
    {
        /// <summary> Получить жанры книг </summary>
        IEnumerable<Genre> GetGenres();
        /// <summary> Получить жанры книг с товарами </summary>
        IEnumerable<Genre> GetGenresWithProducts();
        /// <summary> Получить авторов книг </summary>
        IEnumerable<Author> GetAuthors();
        /// <summary> Получить авторов книг с товарами </summary>
        IEnumerable<Author> GetAuthorsWithProducts();
        /// <summary> Получить товары-книги </summary>
        public IEnumerable<Product> GetProducts(ProductFilter filter = null);
    }
}
