using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBookStore.Domain.Common
{
    /// <summary> Фильтр товаров </summary>
    public class ProductFilter
    {
        /// <summary> Фильтр по жанрам книг </summary>
        public int? GenreId { get; set; }
        /// <summary> Фильтр по авторам книг </summary>
        public int? AuthorId { get; set; }
    }
}
