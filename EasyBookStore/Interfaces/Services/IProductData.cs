using System.Collections.Generic;
using System.Threading.Tasks;
using EasyBookStore.Domain.Common;
using EasyBookStore.Domain.Models;
using Microsoft.VisualBasic;

namespace EasyBookStore.Interfaces.Services
{
    /// <summary> Каталог товаров </summary>
    public interface IProductData
    {
        /// <summary> Получить жанры книг </summary>
        Task<IEnumerable<Genre>> GetGenresAsync();
        /// <summary> Получить жанр книги </summary>
        Task<Genre> GetGenreAsync(int id);
        /// <summary> Получить авторов книг </summary>
        Task<IEnumerable<Author>> GetAuthorsAsync();
        /// <summary> Получить одного автора </summary>
        Task<Author> GetAuthorAsync(int id);
        /// <summary> Получить товары-книги </summary>
        Task<IEnumerable<Product>> GetProductsAsync(ProductFilter filter = null);
        /// <summary> Получить один товар-книгу </summary>
        Task<Product> GetProductAsync(int id);
    }
}
