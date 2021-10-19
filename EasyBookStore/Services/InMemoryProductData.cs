using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBookStore.Domain.Models;
using EasyBookStore.Interfaces.Services;
using EasyBookStore.Models.Data;

namespace EasyBookStore.Services
{
    /// <summary> Сервис хранения данных по товарам в памяти </summary>
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Genre> GetGenres()
        {
            return StaticData.Genres;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return StaticData.Authors;
        }
    }
}
