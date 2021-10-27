using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBookStore.WebModels
{
    public class CatalogWebModel
    {
        /// <summary> Жанр книги </summary>
        public int? GenreId { get; set; }
        /// <summary> Автор книги </summary>
        public int? AuthorId { get; set; }
        /// <summary> Товары </summary>
        public IEnumerable<ProductWebModel> Products { get; set; }
    }
}
