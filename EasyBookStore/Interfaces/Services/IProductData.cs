using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;

namespace EasyBookStore.Interfaces.Services
{
    public interface IProductData
    {
        /// <summary> Получить жанры книг </summary>
        IEnumerable<Genre> GetGenres();
        /// <summary> Получить авторов книг </summary>
        IEnumerable<Author> GetAuthors();
    }
}
